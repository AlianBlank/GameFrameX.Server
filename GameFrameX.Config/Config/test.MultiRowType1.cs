
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
    public sealed partial class MultiRowType1 : BeanBase
    {
        /*
        public MultiRowType1(int Id, int X) 
        {
            this.Id = Id;
            this.X = X;
            PostInit();
        }        
        */

        public MultiRowType1(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            X = _buf.GetProperty("x").GetInt32();
        }
    
        public static MultiRowType1 DeserializeMultiRowType1(JsonElement _buf)
        {
            return new test.MultiRowType1(_buf);
        }

        public int Id { private set; get; }
        public int X { private set; get; }

        private const int __ID__ = 540474970;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "x:" + X + ","
            + "}";
        }

        partial void PostInit();
    }
}
