
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
    public sealed partial class UeBlackboard : ai.Decorator
    {
        /*
        public UeBlackboard(int Id, string NodeName, ai.EFlowAbortMode FlowAbortMode, ai.ENotifyObserverMode NotifyObserver, string BlackboardKey, ai.KeyQueryOperator KeyQuery)  : base(Id, NodeName, FlowAbortMode) 
        {
            this.NotifyObserver = NotifyObserver;
            this.BlackboardKey = BlackboardKey;
            this.KeyQuery = KeyQuery;
            PostInit();
        }        
        */

        public UeBlackboard(JsonElement _buf)  : base(_buf) 
        {
            NotifyObserver = (ai.ENotifyObserverMode)_buf.GetProperty("notify_observer").GetInt32();
            BlackboardKey = _buf.GetProperty("blackboard_key").GetString();
            KeyQuery = ai.KeyQueryOperator.DeserializeKeyQueryOperator(_buf.GetProperty("key_query"));
        }
    
        public static UeBlackboard DeserializeUeBlackboard(JsonElement _buf)
        {
            return new ai.UeBlackboard(_buf);
        }

        public ai.ENotifyObserverMode NotifyObserver { private set; get; }
        public string BlackboardKey { private set; get; }
        public ai.KeyQueryOperator KeyQuery { private set; get; }

        private const int __ID__ = -315297507;
        public override int GetTypeId() => __ID__;

        public override void ResolveRef(TablesComponent tables)
        {
            base.ResolveRef(tables);
            
            
            KeyQuery?.ResolveRef(tables);
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "nodeName:" + NodeName + ","
            + "flowAbortMode:" + FlowAbortMode + ","
            + "notifyObserver:" + NotifyObserver + ","
            + "blackboardKey:" + BlackboardKey + ","
            + "keyQuery:" + KeyQuery + ","
            + "}";
        }

        partial void PostInit();
    }
}
