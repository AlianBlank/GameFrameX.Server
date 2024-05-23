﻿using GameFrameX.Utility;
using Newtonsoft.Json;

namespace GameFrameX.NetWork.HTTP
{
    public class HttpResult
    {
        public static readonly HttpResult Success = new HttpResult(HttpStatusCode.Success, "ok");
        public static readonly HttpResult Undefine = new HttpResult(HttpStatusCode.Undefine, "undefine command");


        public static string Create(HttpStatusCode statusCode = HttpStatusCode.Success, string retMsg = "", object extraMap = null)
        {
            return new HttpResult(statusCode, retMsg, extraMap).ToString();
        }

        public static string CreateOk(string retMsg = "", object extraMap = null)
        {
            return new HttpResult(HttpStatusCode.Success, retMsg, extraMap).ToString();
        }

        public static string CreateErrorParam(string retMsg = "")
        {
            return new HttpResult(HttpStatusCode.ParamErr, retMsg).ToString();
        }

        public static string CreateActionFailed(string retMsg = "")
        {
            return new HttpResult(HttpStatusCode.ActionFailed, retMsg).ToString();
        }

        /// <summary>
        /// 消息码
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public HttpStatusCode Code { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        /// 数据体
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public object Data { get; set; }

        private HttpResult(HttpStatusCode retCode = HttpStatusCode.Success, string retMessage = "ok", object data = null)
        {
            Code = retCode;
            Message = retMessage;
            Data = data;
        }


        public override string ToString()
        {
            return JsonHelper.Serialize(this);
        }

        public static implicit operator string(HttpResult value)
        {
            return value.ToString();
        }

        public static string Create(object data)
        {
            return new HttpResult(HttpStatusCode.Success, HttpStatusMessage.Success, data).ToString();
        }
    }
}