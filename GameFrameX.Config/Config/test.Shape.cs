
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
    public abstract partial class Shape : BeanBase
    {
        /*
        public Shape() 
        {
            PostInit();
        }        
        */

        public Shape(JsonElement _buf) 
        {
        }
    
        public static Shape DeserializeShape(JsonElement _buf)
        {
            switch (_buf.GetProperty("$type").GetString())
            {
                case "Circle": return new test.Circle(_buf);
                case "test2.Rectangle": return new test2.Rectangle(_buf);
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
