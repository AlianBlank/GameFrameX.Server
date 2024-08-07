
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Text.Json;
using GameFrameX.Core.Config;

namespace GameFrameX.Config.tag
{
    public sealed partial class TestTag : BeanBase
    {
        /*
        public TestTag(int Id, string Value) 
        {
            this.Id = Id;
            this.Value = Value;
            PostInit();
        }        
        */

        public TestTag(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            Value = _buf.GetProperty("value").GetString();
        }
    
        public static TestTag DeserializeTestTag(JsonElement _buf)
        {
            return new tag.TestTag(_buf);
        }

        public int Id { private set; get; }
        public string Value { private set; get; }

        private const int __ID__ = 1742933812;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "value:" + Value + ","
            + "}";
        }

        partial void PostInit();
    }
}
