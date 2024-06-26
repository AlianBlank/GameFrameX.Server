using GameFrameX.NetWork.Messages;
using GameFrameX.Proto.Proto;
using ProtoBuf;

namespace GameFrameX.Proto.BuiltIn;

public enum ErrorCode
{
    /// <summary>
    /// 成功
    /// </summary>
    Success = 0,

    /// <summary>
    /// 失败
    /// </summary>
    Fail = 1,

    /// <summary>
    /// 未知
    /// </summary>
    Unknown = 2,

    /// <summary>
    /// 连接达到上限
    /// </summary>
    ConnectionMax = 3
}

/// <summary>
/// 连接到达上限
/// </summary>
[MessageTypeHandler(100000)]
public partial class RespConnected : MessageObject, IResponseMessage
{
    /// <summary>
    /// 错误
    /// </summary>
    [ProtoMember(1)]
    public ErrorCode Code { get; set; }

    /// <summary>
    /// 错误码
    /// </summary>
    [ProtoMember(888)]
    public int ErrorCode { get; set; }
}

/// <summary>
/// 请求Cache连接 目标
/// </summary>
[MessageTypeHandler(2000001)]
public partial class ReqActorCacheTarget : MessageActorObject, IActorRequestMessage
{
    /// <summary>
    ///  时间戳
    /// </summary>
    [ProtoMember(1)]
    public long Timestamp { get; set; }
}

/// <summary>
/// 返回Cache连接 目标
/// </summary>
[MessageTypeHandler(2000001)]
[ProtoContract]
public partial class RespActorCacheTarget : MessageActorObject, IActorResponseMessage
{
    /// <summary>
    ///  时间戳
    /// </summary>
    [ProtoMember(1)]
    public long Timestamp { get; set; }

    /// <summary>
    /// 错误码
    /// </summary>
    [ProtoMember(888)]
    public int ErrorCode { get; set; }
}

/// <summary>
/// 请求心跳
/// </summary>
[MessageTypeHandler(1000001)]
public partial class ReqActorHeartBeat : MessageActorObject, IActorRequestMessage
{
    /// <summary>
    ///  时间戳
    /// </summary>
    [ProtoMember(1)]
    public long Timestamp { get; set; }
}

/// <summary>
/// 返回心跳
/// </summary>
[MessageTypeHandler(1000001)]
[ProtoContract]
public partial class RespActorHeartBeat : MessageActorObject, IActorResponseMessage
{
    /// <summary>
    ///  时间戳
    /// </summary>
    [ProtoMember(1)]
    public long Timestamp { get; set; }

    /// <summary>
    /// 错误码
    /// </summary>
    [ProtoMember(888)]
    public int ErrorCode { get; set; }
}