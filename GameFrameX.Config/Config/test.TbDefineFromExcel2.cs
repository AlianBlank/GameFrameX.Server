
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
    public partial class TbDefineFromExcel2 : BaseDataTable<DefineFromExcel2>
    {
        //private readonly System.Collections.Generic.Dictionary<int, DefineFromExcel2> _dataMap;
        //private readonly System.Collections.Generic.List<DefineFromExcel2> _dataList;
    
        //public System.Collections.Generic.Dictionary<int, DefineFromExcel2> DataMap => _dataMap;
        //public System.Collections.Generic.List<DefineFromExcel2> DataList => _dataList;
        //public DefineFromExcel2 GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        //public DefineFromExcel2 Get(int key) => _dataMap[key];
        //public DefineFromExcel2 this[int key] => _dataMap[key];
    
        public override async System.Threading.Tasks.Task LoadAsync()
        {
            var jsonElement = await _loadFunc();
            DataList.Clear();
            LongDataMaps.Clear();
            StringDataMaps.Clear();
            foreach(var element in jsonElement.EnumerateArray())
            {
                DefineFromExcel2 _v;
                _v = DefineFromExcel2.DeserializeDefineFromExcel2(element);
                DataList.Add(_v);
                LongDataMaps.Add(_v.Id, _v);
                StringDataMaps.Add(_v.Id.ToString(), _v);
            }
            PostInit();
        }

        public void ResolveRef(TablesComponent tables)
        {
            foreach(var element in DataList)
            {
                element.ResolveRef(tables);
            }
        }
    
    
        partial void PostInit();

        public TbDefineFromExcel2(Func<Task<JsonElement>> loadFunc) : base(loadFunc)
        {
        }
    }
}
