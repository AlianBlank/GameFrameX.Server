
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Text.Json;
using GameFrameX.Core.Config;

namespace GameFrameX.Config.item
{
    /// <summary>
    /// 道具
    /// </summary>
    public sealed partial class Item : BeanBase
    {
        /*
        public Item(int Id, string Name, item.EMajorType MajorType, item.EMinorType MinorType, int MaxPileNum, item.EItemQuality Quality, string IconBackgroud, string IconMask, string Desc, int ShowOrder) 
        {
            this.Id = Id;
            this.Name = Name;
            this.MajorType = MajorType;
            this.MinorType = MinorType;
            this.MaxPileNum = MaxPileNum;
            this.Quality = Quality;
            this.IconBackgroud = IconBackgroud;
            this.IconMask = IconMask;
            this.Desc = Desc;
            this.ShowOrder = ShowOrder;
            PostInit();
        }        
        */

        public Item(JsonElement _buf) 
        {
            Id = _buf.GetProperty("id").GetInt32();
            Name = _buf.GetProperty("name").GetString();
            MajorType = (item.EMajorType)_buf.GetProperty("major_type").GetInt32();
            MinorType = (item.EMinorType)_buf.GetProperty("minor_type").GetInt32();
            MaxPileNum = _buf.GetProperty("max_pile_num").GetInt32();
            Quality = (item.EItemQuality)_buf.GetProperty("quality").GetInt32();
            IconBackgroud = _buf.GetProperty("icon_backgroud").GetString();
            IconMask = _buf.GetProperty("icon_mask").GetString();
            Desc = _buf.GetProperty("desc").GetString();
            ShowOrder = _buf.GetProperty("show_order").GetInt32();
        }
    
        public static Item DeserializeItem(JsonElement _buf)
        {
            return new item.Item(_buf);
        }

        /// <summary>
        /// 道具id
        /// </summary>
        public int Id { private set; get; }
        public string Name { private set; get; }
        public item.EMajorType MajorType { private set; get; }
        public item.EMinorType MinorType { private set; get; }
        public int MaxPileNum { private set; get; }
        public item.EItemQuality Quality { private set; get; }
        public string IconBackgroud { private set; get; }
        public string IconMask { private set; get; }
        public string Desc { private set; get; }
        public int ShowOrder { private set; get; }

        private const int __ID__ = 2107285806;
        public override int GetTypeId() => __ID__;

        public  void ResolveRef(TablesComponent tables)
        {
            
            
            
            
            
            
            
            
            
            
        }

        public override string ToString()
        {
            return "{ "
            + "id:" + Id + ","
            + "name:" + Name + ","
            + "majorType:" + MajorType + ","
            + "minorType:" + MinorType + ","
            + "maxPileNum:" + MaxPileNum + ","
            + "quality:" + Quality + ","
            + "iconBackgroud:" + IconBackgroud + ","
            + "iconMask:" + IconMask + ","
            + "desc:" + Desc + ","
            + "showOrder:" + ShowOrder + ","
            + "}";
        }

        partial void PostInit();
    }
}
