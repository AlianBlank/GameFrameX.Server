
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
    public sealed partial class GetOwnerPlayer : ai.Service
    {
        /*
        public GetOwnerPlayer(int Id, string NodeName, string PlayerActorKey)  : base(Id, NodeName) 
        {
            this.PlayerActorKey = PlayerActorKey;
            PostInit();
        }        
        */

        public GetOwnerPlayer(JsonElement _buf)  : base(_buf) 
        {
            PlayerActorKey = _buf.GetProperty("player_actor_key").GetString();
        }
    
        public static GetOwnerPlayer DeserializeGetOwnerPlayer(JsonElement _buf)
        {
            return new ai.GetOwnerPlayer(_buf);
        }

        public string PlayerActorKey { private set; get; }

        private const int __ID__ = -999247644;
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
            + "playerActorKey:" + PlayerActorKey + ","
            + "}";
        }

        partial void PostInit();
    }
}
