
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
    public sealed partial class BehaviorTree : BeanBase
    {
        /*
        public BehaviorTree(int Id, string Name, string Desc, string BlackboardId, ai.ComposeNode Root) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Desc = Desc;
            this.BlackboardId = BlackboardId;
            this.BlackboardId_Ref = null;
            this.Root = Root;
            PostInit();
        }        
        */

        public BehaviorTree(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            Name = _buf.GetProperty("name").GetString();
            Desc = _buf.GetProperty("desc").GetString();
            BlackboardId = _buf.GetProperty("blackboard_id").GetString();
            BlackboardId_Ref = null;
            Root = ai.ComposeNode.DeserializeComposeNode(_buf.GetProperty("root"));
        }
    
        public static BehaviorTree DeserializeBehaviorTree(JsonElement _buf)
        {
            return new ai.BehaviorTree(_buf);
        }

        public int Id { private set; get; }
        public string Name { private set; get; }
        public string Desc { private set; get; }
        public string BlackboardId { private set; get; }
        public ai.Blackboard BlackboardId_Ref { private set; get; }
        public ai.ComposeNode Root { private set; get; }

        private const int __ID__ = 159552822;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
            
            BlackboardId_Ref = tables.TbBlackboard.Get(BlackboardId);
            Root?.ResolveRef(tables);
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "name:" + Name + ","
            + "desc:" + Desc + ","
            + "blackboardId:" + BlackboardId + ","
            + "root:" + Root + ","
            + "}";
        }

        partial void PostInit();
    }
}
