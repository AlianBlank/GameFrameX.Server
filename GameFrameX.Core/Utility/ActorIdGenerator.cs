﻿using GameFrameX.Core.Abstractions;
using GameFrameX.Setting;
using GameFrameX.Utility;

namespace GameFrameX.Core.Utility
{
    /// <summary>
    /// ActorId 生成器
    ///     14   +   7  + 30 +  12   = 63
    ///     服务器id 类型 时间戳 自增
    ///         玩家
    ///         公会
    ///     服务器id * 100000 + 全局功能id
    ///         全局玩法
    /// </summary>
    public static class ActorIdGenerator
    {
        private static long _genSecond = 0L;
        private static long _incrNum   = 0L;


        private static readonly object LockObj = new();

        /// <summary>
        /// 根据ActorId获取服务器id
        /// </summary>
        /// <param name="actorId">ActorId</param>
        /// <returns>服务器id</returns>
        public static int GetServerId(long actorId)
        {
            if (actorId < GlobalConst.MinServerId)
            {
                throw new ArgumentOutOfRangeException(nameof(actorId), "actorId is less than min server id, min server id is " + GlobalConst.MinServerId);
            }

            if (actorId < GlobalConst.MaxGlobalId)
            {
                return (int)(actorId / 1000);
            }

            return (int)(actorId >> GlobalConst.ServerIdOrModuleIdMask);
        }

        /// <summary>
        /// 根据ActorId获取生成时间
        /// </summary>
        /// <param name="actorId">ActorId</param>
        /// <param name="isUtc">是否使用UTC</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /*public static DateTime GetGenerateTime(long actorId, bool isUtc = false)
        {
            if (actorId < GlobalConst.MaxGlobalId)
            {
                throw new ArgumentException($"input is a global id:{actorId}");
            }

            var  serverId = GetServerId(actorId);
            long seconds;
            if (serverId < GlobalConst.MinServerId)
            {
                // IDModule unique_id
                seconds = (actorId >> GlobalConst.ModuleIdTimestampMask) & GlobalConst.SecondMask;
            }
            else
            {
                seconds = (actorId >> GlobalConst.TimestampMask) & GlobalConst.SecondMask;
            }

            var date = IdGenerator.UtcTimeStart.AddSeconds(seconds);
            return isUtc ? date : date.ToLocalTime();
        }*/

        /// <summary>
        /// 根据ActorId获取ActorType
        /// </summary>
        /// <param name="actorId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ActorType GetActorType(long actorId)
        {
            if (actorId < GlobalConst.MinServerId)
            {
                throw new ArgumentOutOfRangeException(nameof(actorId), "actorId is less than min server id, min server id is " + GlobalConst.MinServerId);
            }

            if (actorId < GlobalConst.MaxGlobalId)
            {
                // 全局actor
                return (ActorType)(actorId % 1000);
            }

            return (ActorType)((actorId >> GlobalConst.ActorTypeMask) & 0xFF);
        }


        /// <summary>
        /// 根据ActorType获取ActorId
        /// </summary>
        /// <param name="type"></param>
        /// <param name="serverId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static long GetActorId(ActorType type, int serverId = 0)
        {
            if (type == ActorType.Separator)
            {
                throw new ArgumentException($"input actor type error: {type}");
            }

            if (serverId < 0)
            {
                throw new ArgumentException($"serverId negtive when generate id {serverId}");
            }

            if (serverId == 0)
            {
                serverId = GlobalSettings.ServerId;
            }

            if (type < ActorType.Separator)
            {
                return GetMultiActorId(type, serverId);
            }

            return GetGlobalActorId(type, serverId);
        }

        /// <summary>
        /// 根据ActorType类型和服务器id获取ActorId
        /// </summary>
        /// <param name="actorType">ActorType</param>
        /// <param name="serverId">服务器ID</param>
        /// <returns></returns>
        public static long GetGlobalActorId(ActorType actorType, int serverId)
        {
            if (serverId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(serverId), "serverId is less than 0");
            }

            if (actorType >= ActorType.Max || actorType == ActorType.Separator || actorType == ActorType.None)
            {
                throw new ArgumentOutOfRangeException(nameof(actorType), "type is invalid");
            }

            return serverId * 1000 + (int)actorType;
        }


        /// <summary>
        /// 根据ActorType类型和服务器id获取ActorId
        /// </summary>
        /// <param name="actorType">ActorType</param>
        /// <param name="serverId">服务器ID</param>
        /// <returns></returns>
        public static long GetMultiActorId(ActorType actorType, int serverId)
        {
            if (serverId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(serverId), "serverId is less than 0");
            }

            long second = (long)(DateTime.UtcNow - IdGenerator.UtcTimeStart).TotalSeconds;
            lock (LockObj)
            {
                if (second > _genSecond)
                {
                    _genSecond = second;
                    _incrNum   = 0L;
                }
                else if (_incrNum >= GlobalConst.MaxActorIncrease)
                {
                    ++_genSecond;
                    _incrNum = 0L;
                }
                else
                {
                    ++_incrNum;
                }
            }

            var actorId = (long)serverId << GlobalConst.ServerIdOrModuleIdMask; // serverId-14位, 支持1000~9999
            actorId |= (long)actorType << GlobalConst.ActorTypeMask; // 多actor类型-7位, 支持0~127
            actorId |= _genSecond << GlobalConst.TimestampMask; // 时间戳-30位, 支持34年
            actorId |= _incrNum; // 自增-12位, 每秒4096个
            return actorId;
        }


        /// <summary>
        /// 生成账号的唯一ID
        /// </summary>
        /// <returns></returns>
        public static long GetAccountUniqueId()
        {
            return GetUniqueId(IdModule.Account);
        }

        /// <summary>
        /// 生成玩家的唯一ID
        /// </summary>
        /// <returns></returns>
        public static long GetPlayerUniqueId()
        {
            return GetUniqueId(IdModule.Player);
        }

        /// <summary>
        /// 根据模块获取唯一ID
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static long GetUniqueId(IdModule module)
        {
            long second = (long)(DateTime.UtcNow - IdGenerator.UtcTimeStart).TotalSeconds;
            lock (LockObj)
            {
                if (second > _genSecond)
                {
                    _genSecond = second;
                    _incrNum   = 0L;
                }
                else if (_incrNum >= GlobalConst.MaxUniqueIncrease)
                {
                    ++_genSecond;
                    _incrNum = 0L;
                }
                else
                {
                    ++_incrNum;
                }
            }

            var id = (long)module << GlobalConst.ServerIdOrModuleIdMask; // 模块id 14位 支持 0~9999
            lock (LockObj)
            {
                id |= _genSecond << GlobalConst.ModuleIdTimestampMask; // 时间戳 30位
            }

            id |= _incrNum; // 自增 19位
            return id;
        }
    }
}