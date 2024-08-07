
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Text.Json;
using GameFrameX.Core.Config;

namespace GameFrameX.Config.ai
{
    public sealed partial class UeWait : ai.Task
    {
        /*
        public UeWait(int Id, string NodeName, System.Collections.Generic.List<ai.Decorator> Decorators, System.Collections.Generic.List<ai.Service> Services, bool IgnoreRestartSelf, float WaitTime, float RandomDeviation)  : base(Id, NodeName, Decorators, Services, IgnoreRestartSelf) 
        {
            this.WaitTime = WaitTime;
            this.RandomDeviation = RandomDeviation;
            PostInit();
        }        
        */

        public UeWait(JsonElement _buf)  : base(_buf) 
        {
            WaitTime = _buf.GetProperty("wait_time").GetSingle();
            RandomDeviation = _buf.GetProperty("random_deviation").GetSingle();
        }
    
        public static UeWait DeserializeUeWait(JsonElement _buf)
        {
            return new ai.UeWait(_buf);
        }

        public float WaitTime { private set; get; }
        public float RandomDeviation { private set; get; }

        private const int __ID__ = -512994101;
        public override int GetTypeId() => __ID__;

        public override void ResolveRef(TablesComponent tables)
        {
            base.ResolveRef(tables);
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "nodeName:" + NodeName + ","
            + "decorators:" + StringUtil.CollectionToString(Decorators) + ","
            + "services:" + StringUtil.CollectionToString(Services) + ","
            + "ignoreRestartSelf:" + IgnoreRestartSelf + ","
            + "waitTime:" + WaitTime + ","
            + "randomDeviation:" + RandomDeviation + ","
            + "}";
        }

        partial void PostInit();
    }
}
