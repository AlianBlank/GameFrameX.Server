
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
    public sealed partial class MultiRowType2 : BeanBase
    {
        /*
        public MultiRowType2(int Id, int X, float Y) 
        {
            this.Id = Id;
            this.X = X;
            this.Y = Y;
            PostInit();
        }        
        */

        public MultiRowType2(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            X = _buf.GetProperty("x").GetInt32();
            Y = _buf.GetProperty("y").GetSingle();
        }
    
        public static MultiRowType2 DeserializeMultiRowType2(JsonElement _buf)
        {
            return new test.MultiRowType2(_buf);
        }

        public int Id { private set; get; }
        public int X { private set; get; }
        public float Y { private set; get; }

        private const int __ID__ = 540474971;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "x:" + X + ","
            + "y:" + Y + ","
            + "}";
        }

        partial void PostInit();
    }
}
