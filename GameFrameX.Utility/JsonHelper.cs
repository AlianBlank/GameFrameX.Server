﻿using GameFrameX.Extension;

namespace GameFrameX.Utility;

/// <summary>
/// Json 帮助类
/// </summary>
public static class JsonHelper
{
    /// <summary>
    /// 序列化对象
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static string Serialize(object obj)
    {
        obj.CheckNotNull(nameof(obj));
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        return json;
    }

    /// <summary>
    /// 反序列化对象
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(string json) where T : class, new()
    {
        json.CheckNotNullOrEmpty(nameof(json));
        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
    }
}