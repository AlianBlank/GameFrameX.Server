
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Text.Json;
using GameFrameX.Core.Config;

namespace GameFrameX.Config.l10n
{
    public sealed partial class PatchDemo : BeanBase
    {
        /*
        public PatchDemo(int Id, int Value) 
        {
            this.Id = Id;
            this.Value = Value;
            PostInit();
        }        
        */

        public PatchDemo(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            Value = _buf.GetProperty("value").GetInt32();
        }
    
        public static PatchDemo DeserializePatchDemo(JsonElement _buf)
        {
            return new l10n.PatchDemo(_buf);
        }

        public int Id { private set; get; }
        public int Value { private set; get; }

        private const int __ID__ = -1707294656;
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
