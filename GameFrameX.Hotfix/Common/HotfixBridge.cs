﻿using GameFrameX.Hotfix.StartUp;
using GameFrameX.Launcher;
using GameFrameX.Launcher.Common.Session;
using GameFrameX.NetWork.HTTP;
using GameFrameX.NetWork.Messages;

namespace GameFrameX.Hotfix.Common
{
    internal partial class HotfixBridge : IHotfixBridge
    {
        public  ServerType   BridgeType => ServerType.Game;
        private AppSetting   Setting    { get; set; }
        AppStartUpHotfixGame _appStartUpHotfixGame;

        public async Task<bool> OnLoadSuccess(AppSetting setting, bool reload)
        {
            Setting = setting;
            if (reload)
            {
                ActorManager.ClearAgent();
                return true;
            }

            _appStartUpHotfixGame = new AppStartUpHotfixGame();
            _appStartUpHotfixGame.Init(setting.ServerType, setting);
            await _appStartUpHotfixGame.StartAsync();
            RunServer(reload);
            GlobalTimer.Start();
            await ComponentRegister.ActiveGlobalComponents();
            return true;
        }

        public async Task Stop()
        {
            // 断开所有连接
            await SessionManager.RemoveAll();
            // 取消所有未执行定时器
            await QuartzTimer.Stop();
            // 保证actor之前的任务都执行完毕
            await ActorManager.AllFinish();
            _appStartUpHotfixGame?.StopAsync();
            await HttpServer.Stop();
            // 存储所有数据
            await GlobalTimer.Stop();
            await ActorManager.RemoveAll();
        }
    }
}