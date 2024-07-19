
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
    public partial class TbDemoPrimitive : BaseDataTable<test.DemoPrimitiveTypesTable>
    {
        //private readonly System.Collections.Generic.Dictionary<int, test.DemoPrimitiveTypesTable> _dataMap;
        //private readonly System.Collections.Generic.List<test.DemoPrimitiveTypesTable> _dataList;
    
        //public System.Collections.Generic.Dictionary<int, test.DemoPrimitiveTypesTable> DataMap => _dataMap;
        //public System.Collections.Generic.List<test.DemoPrimitiveTypesTable> DataList => _dataList;
        //public test.DemoPrimitiveTypesTable GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
        //public test.DemoPrimitiveTypesTable Get(int key) => _dataMap[key];
        //public test.DemoPrimitiveTypesTable this[int key] => _dataMap[key];
    
        public override async System.Threading.Tasks.Task LoadAsync()
        {
            var jsonElement = await _loadFunc();
            DataList.Clear();
            LongDataMaps.Clear();
            StringDataMaps.Clear();
            foreach(var element in jsonElement.EnumerateArray())
            {
                test.DemoPrimitiveTypesTable _v;
                _v = test.DemoPrimitiveTypesTable.DeserializeDemoPrimitiveTypesTable(element);
                DataList.Add(_v);
                LongDataMaps.Add(_v.X4, _v);
                StringDataMaps.Add(_v.X4.ToString(), _v);
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

        public TbDemoPrimitive(Func<Task<JsonElement>> loadFunc) : base(loadFunc)
        {
        }
    }
}
