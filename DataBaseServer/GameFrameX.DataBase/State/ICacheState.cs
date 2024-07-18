namespace GameFrameX.DataBase.State;

/// <summary>
/// 缓存数据对象接口
/// </summary>
public interface ICacheState : ISafeDelete, ISafeCreate, ISafeUpdate
{
    /// <summary>
    /// 唯一ID
    /// </summary>
    long Id { get; set; }

    /// <summary>
    /// 是否修改
    /// </summary>
    bool IsModify { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isNew"></param>
    void AfterLoadFromDb(bool isNew);

    /// <summary>
    /// 
    /// </summary>
    void AfterSaveToDb();

    /// <summary>
    /// 将对象序列化转换为字节数组
    /// </summary>
    /// <returns></returns>
    byte[] ToBytes();
}