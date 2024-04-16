﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using GameFrameX.Launcher.PipelineFilter;
using GameFrameX.NetWork;
using GameFrameX.NetWork.Messages;
using GameFrameX.Setting;
using GameFrameX.Utility;
using SuperSocket.Channel;
using ErrorEventArgs = SuperSocket.ClientEngine.ErrorEventArgs;
using SuperSocket.WebSocket.Server;
using SuperSocket.WebSocket;
using CloseReason = SuperSocket.Channel.CloseReason;

/// <summary>
/// 路由服务器.最后启动。
/// </summary>
[StartUpTag(ServerType.Router, Int32.MaxValue)]
internal sealed class AppStartUpRouter : AppStartUpBase
{
    /// <summary>
    /// 链接到网关的客户端
    /// </summary>
    private AsyncTcpSession client;

    /// <summary>
    /// 服务器。对外提供服务
    /// </summary>
    IServer server;


    public override async Task EnterAsync()
    {
        try
        {
            await StartServer();
            LogHelper.Info($"启动服务器 {ServerType} 端口: {Setting.TcpPort} 结束!");
            StartClient();
            await AppExitToken;
            LogHelper.Info("全部断开...");
            await Stop();
            LogHelper.Info("Done!");
        }
        catch (Exception e)
        {
            await Stop(e.Message);
        }
    }

    /// <summary>
    /// 重连定时器
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void ReconnectionTimerOnElapsed(object sender, ElapsedEventArgs e)
    {
        // 重连到网关服务器
        ConnectToGateWay();
    }

    private void ConnectToGateWay()
    {
        client.Connect(new DnsEndPoint(Setting.CenterUrl, Setting.GrpcPort));
    }

    private void StartClient()
    {
        client = new AsyncTcpSession();
        client.Connected += ClientOnConnected;
        client.Closed += ClientOnClosed;
        client.Error += ClientOnError;
        client.DataReceived += ClientOnDataReceived;
        LogHelper.Info("开始链接到网关服务器 ...");
        ConnectToGateWay();
    }

    private void ClientOnError(object sender, ErrorEventArgs e)
    {
        LogHelper.Error("和网关服务器链接链接失败!.下一次重连时间:" + DateTime.Now.AddMilliseconds(ReconnectionTimer.Interval));
        // 和网关服务器链接失败，开启重连
        ReconnectionTimer.Start();
    }

    private void ClientOnDataReceived(object sender, DataEventArgs e)
    {
        LogHelper.Info("收到网关服务器返回的消息!" + e);
    }

    private void ClientOnClosed(object sender, EventArgs e)
    {
        LogHelper.Info("和网关服务器链接链接断开!");
        // 和网关服务器链接断开，开启重连
        ReconnectionTimer.Start();
    }

    private void ClientOnConnected(object sender, EventArgs e)
    {
        LogHelper.Info("和网关服务器链接链接成功!");
        // 和网关服务器链接成功，关闭重连
        ReconnectionTimer.Stop();
        // 开启和网关服务器的心跳
        HeartBeatTimer.Start();
    }

    private IHost webSocketServer;

    private async Task StartServer()
    {
        webSocketServer = WebSocketHostBuilder.Create()
            .UseWebSocketMessageHandler(WebSocketMessageHandler)
            .ConfigureAppConfiguration((ConfigureWebServer)).Build();
        await webSocketServer.StartAsync();
        server = SuperSocketHostBuilder.Create<IMessage, MessageObjectPipelineFilter>()
            .ConfigureSuperSocket(ConfigureSuperSocket)
            .UseClearIdleSession()
            .UsePackageDecoder<MessageRouterDecoderHandler>()
            // .UsePackageEncoder<MessageEncoderHandler>()
            .UseSessionHandler(OnConnected, OnDisconnected)
            .UsePackageHandler(ClientPackageHandler, ClientErrorHandler)
            .UseInProcSessionContainer()
            .BuildAsServer();

        await server.StartAsync();
    }

    private ValueTask<bool> ClientErrorHandler(IAppSession appSession, PackageHandlingException<IMessage> exception)
    {
        return ValueTask.FromResult(false);
    }

    private void ConfigureWebServer(HostBuilderContext context, IConfigurationBuilder builder)
    {
        builder.AddInMemoryCollection(new Dictionary<string, string>()
            { { "serverOptions:name", "TestServer" }, { "serverOptions:listeners:0:ip", "Any" }, { "serverOptions:listeners:0:port", Setting.WsPort.ToString() } });
    }

    /// <summary>
    /// 处理收到的WS消息
    /// </summary>
    /// <param name="session"></param>
    /// <param name="message"></param>
    private async ValueTask WebSocketMessageHandler(WebSocketSession session, WebSocketPackage message)
    {
        if (message.OpCode != OpCode.Binary)
        {
            await session.CloseAsync(CloseReason.ProtocolError);
            return;
        }

        var bytes = message.Data;
        var buffer = bytes.ToArray();
        var messageObject = messageRouterDecoderHandler.Handler(buffer);
        await MessagePackageHandler(session, messageObject);
    }

    /// <summary>
    /// 处理收到的消息结果
    /// </summary>
    /// <param name="session"></param>
    /// <param name="messageObject"></param>
    private async ValueTask MessagePackageHandler(IAppSession session, IMessage messageObject)
    {
        if (messageObject is MessageObject message)
        {
            var messageId = message.MessageId;
            if (Setting.IsDebug && Setting.IsDebugReceive)
            {
                LogHelper.Debug($"---收到消息ID:[{messageId}] ==>消息类型:{message.GetType()} 消息内容:{messageObject}");
            }

            var handler = HotfixMgr.GetTcpHandler(message.MessageId);
            if (handler == null)
            {
                LogHelper.Error($"找不到[{message.MessageId}][{messageObject.GetType()}]对应的handler");
                return;
            }

            // RespHeartBeat resp = new RespHeartBeat
            // {
            //     Timestamp = TimeHelper.UnixTimeMilliseconds()
            // };
            // var messageData = messageEncoderHandler.Handler(resp);
            // await session.SendAsync(messageData);
            handler.Message = message;
            handler.Channel = new DefaultNetChannel(session, messageEncoderHandler); // session;
            await handler.Init();
            await handler.InnerAction();
        }
    }

    private MessageRouterDecoderHandler messageRouterDecoderHandler = new MessageRouterDecoderHandler();
    static readonly MessageRouterEncoderHandler messageEncoderHandler = new MessageRouterEncoderHandler();

    private async ValueTask ClientPackageHandler(IAppSession session, IMessage messageObject)
    {
        if (messageObject is MessageObject msg)
        {
            var messageId = msg.MessageId;
            if (Setting.IsDebug && Setting.IsDebugReceive)
            {
                LogHelper.Debug($"---收到消息ID:[{messageId}] ==>消息类型:{msg.GetType()} 消息内容:{messageObject}");
            }
        }

        // 发送
        var response = new RespHeartBeat()
        {
            Timestamp = TimeHelper.UnixTimeSeconds()
        };
        var messageData = messageEncoderHandler.Handler(response);
        await session.SendAsync(messageData);
    }


    private ValueTask OnConnected(IAppSession appSession)
    {
        LogHelper.Info("有外部客户端网络连接成功！。链接信息：SessionID:" + appSession.SessionID + " RemoteEndPoint:" + appSession.RemoteEndPoint);
        // NamingServiceManager.Instance.Add();
        return ValueTask.CompletedTask;
    }

    private ValueTask OnDisconnected(object sender, CloseEventArgs args)
    {
        LogHelper.Info("有外部客户端网络断开连接成功！。断开信息：" + args.Reason);
        return ValueTask.CompletedTask;
    }

    public override async Task Stop(string message = "")
    {
        HeartBeatTimer.Close();
        ReconnectionTimer.Close();
        tcpClient.Close();
        await webSocketServer.StopAsync();
        await tcpService.StopAsync();
        await base.Stop(message);
    }

    protected override void Init()
    {
        if (Setting == null)
        {
            Setting = new AppSetting
            {
                ServerId = 1000,
                ServerType = ServerType.Router,
                TcpPort = 21000,
                WsPort = 21100,
                WssPort = 21200,
                // 网关配置
                GrpcPort = 22000,
                CenterUrl = "127.0.0.1",
            };
            if (PlatformRuntimeHelper.IsLinux)
            {
                Setting.CenterUrl = "gateway";
            }
        }

        base.Init();
    }
}