
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
    public sealed partial class MultiIndexList : BeanBase
    {
        /*
        public MultiIndexList(int Id1, long Id2, string Id3, int Num, string Desc) 
        {
            this.Id1 = Id1;
            this.Id2 = Id2;
            this.Id3 = Id3;
            this.Num = Num;
            this.Desc = Desc;
            PostInit();
        }        
        */

        public MultiIndexList(JsonElement _buf) 
        {
            Id1 = _buf.GetProperty("id1").GetInt32();
            Id2 = _buf.GetProperty("id2").GetInt64();
            Id3 = _buf.GetProperty("id3").GetString();
            Num = _buf.GetProperty("num").GetInt32();
            Desc = _buf.GetProperty("desc").GetString();
        }
    
        public static MultiIndexList DeserializeMultiIndexList(JsonElement _buf)
        {
            return new test.MultiIndexList(_buf);
        }

        public int Id1 { private set; get; }
        public long Id2 { private set; get; }
        public string Id3 { private set; get; }
        public int Num { private set; get; }
        public string Desc { private set; get; }

        private const int __ID__ = 2016237651;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id1:" + Id1 + ","
            + "id2:" + Id2 + ","
            + "id3:" + Id3 + ","
            + "num:" + Num + ","
            + "desc:" + Desc + ","
            + "}";
        }

        partial void PostInit();
    }
}
