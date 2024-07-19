using GameFrameX.DataBase.State;
using GameFrameX.Log;
using GameFrameX.Utility;

namespace GameFrameX.DataBase.Storage;

class StateMd5
{
    private BaseCacheState State { get; }

    public StateMd5(BaseCacheState state, bool isNew, string cacheMd5, string toSaveMd5)
    {
        State     = state;
        CacheMd5  = cacheMd5;
        ToSaveMd5 = toSaveMd5;
        if (!isNew)
        {
            CacheMd5 = GetMd5AndData(state).md5;
        }
    }

    private string CacheMd5 { get; set; }

    private string ToSaveMd5 { get; set; }

    public (bool, byte[]) IsChanged()
    {
        var (toSaveMd5, data) = GetMd5AndData(State);
        ToSaveMd5             = toSaveMd5;
        return (CacheMd5 == default || toSaveMd5 != CacheMd5, data);
    }

    public void AfterSaveToDb()
    {
        if (CacheMd5 == ToSaveMd5)
        {
            LogHelper.Error($"调用AfterSaveToDB前CacheMD5已经等于ToSaveMD5 {State}");
        }

        CacheMd5 = ToSaveMd5;
    }

    private static (string md5, byte[] data) GetMd5AndData(BaseCacheState state)
    {
        var data   = state.ToBytes();
        var md5Str = Hash.MD5.Hash(data);
        return (md5Str, data);
    }
}