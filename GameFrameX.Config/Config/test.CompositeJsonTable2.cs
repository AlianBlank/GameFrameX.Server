
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Text.Json;
using GameFrameX.Core.Config;

namespace GameFrameX.Config.test
{
    public sealed partial class CompositeJsonTable2 : BeanBase
    {
        /*
        public CompositeJsonTable2(int Id, int Y) 
        {
            this.Id = Id;
            this.Y = Y;
            PostInit();
        }        
        */

        public CompositeJsonTable2(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            Y = _buf.GetProperty("y").GetInt32();
        }
    
        public static CompositeJsonTable2 DeserializeCompositeJsonTable2(JsonElement _buf)
        {
            return new test.CompositeJsonTable2(_buf);
        }

        public int Id { private set; get; }
        public int Y { private set; get; }

        private const int __ID__ = 1566207895;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "y:" + Y + ","
            + "}";
        }

        partial void PostInit();
    }
}
