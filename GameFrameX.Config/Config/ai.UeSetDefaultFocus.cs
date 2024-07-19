
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
    public sealed partial class UeSetDefaultFocus : ai.Service
    {
        /*
        public UeSetDefaultFocus(int Id, string NodeName, string KeyboardKey)  : base(Id, NodeName) 
        {
            this.KeyboardKey = KeyboardKey;
            PostInit();
        }        
        */

        public UeSetDefaultFocus(JsonElement _buf)  : base(_buf) 
        {
            KeyboardKey = _buf.GetProperty("keyboard_key").GetString();
        }
    
        public static UeSetDefaultFocus DeserializeUeSetDefaultFocus(JsonElement _buf)
        {
            return new ai.UeSetDefaultFocus(_buf);
        }

        public string KeyboardKey { private set; get; }

        private const int __ID__ = 1812449155;
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
            + "keyboardKey:" + KeyboardKey + ","
            + "}";
        }

        partial void PostInit();
    }
}
