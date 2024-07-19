﻿namespace GameFrameX.Core.Abstractions;

/// <summary>
/// 工作Actor接口定义
/// </summary>
public interface IWorkerActor : IWorker
{
    /// <summary>
    /// 是否需要入队
    /// </summary>
    /// <returns></returns>
    (bool needEnqueue, long chainId) IsNeedEnqueue();

    /// <summary>
    /// 入队
    /// </summary>
    /// <param name="func">有返回值的委托</param>
    /// <param name="callChainId">调用链ID</param>
    /// <param name="discard">是否强制入队</param>
    /// <param name="timeOut">超时时间</param>
    Task Enqueue(Func<Task> func, long callChainId, bool discard = false, int timeOut = int.MaxValue);
}