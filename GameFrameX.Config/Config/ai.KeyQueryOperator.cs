
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
    public abstract partial class KeyQueryOperator : BeanBase
    {
        /*
        public KeyQueryOperator() 
        {
            PostInit();
        }        
        */

        public KeyQueryOperator(JsonElement _buf) 
        {
        }
    
        public static KeyQueryOperator DeserializeKeyQueryOperator(JsonElement _buf)
        {
            switch (_buf.GetProperty("$type").GetString())
            {
                case "IsSet2": return new ai.IsSet2(_buf);
                case "IsNotSet": return new ai.IsNotSet(_buf);
                case "BinaryOperator": return new ai.BinaryOperator(_buf);
                default: throw new SerializationException();
            }
        }



        public virtual void ResolveRef(TablesComponent tables)
        {
        }

        public override string ToString()
        {
            return "{ "
            + "}";
        }

        partial void PostInit();
    }
}
