
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
    public sealed partial class DemoType1 : BeanBase
    {
        /*
        public DemoType1(int X1) 
        {
            this.X1 = X1;
            PostInit();
        }        
        */

        public DemoType1(JsonElement _buf) 
        {
            X1 = _buf.GetProperty("x1").GetInt32();
        }
    
        public static DemoType1 DeserializeDemoType1(JsonElement _buf)
        {
            return new test.DemoType1(_buf);
        }

        public int X1 { private set; get; }

        private const int __ID__ = -367048296;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
        }

        public override string ToString()
        {
            return "{ "
            + "x1:" + X1 + ","
            + "}";
        }

        partial void PostInit();
    }
}
