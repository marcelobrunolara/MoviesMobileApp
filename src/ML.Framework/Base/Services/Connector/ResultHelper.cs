using ML.Framework.Base.Services.Models;
using System;
using System.Net;

namespace ML.Framework.Base.Services.Connector
{
    public class ResultHelper
    {
        public static Result<T> MakeErrorMessage<T>(HttpStatusCode errorCode, string reason, T errorContent) 
        {
            string mensagem = string.Join("-", (int)errorCode, reason);
            return Result<T>.Create(false, mensagem, errorContent, (int)errorCode);
        }

        public static Result<T> MakeResponseContentMessage<T>(T responseContent)
        {
            return Result<T>.Create(true, string.Empty, responseContent, (int)HttpStatusCode.OK);
        }

        public static Result<T> MakeExceptionMessage<T>(Exception e)
        {
            return Result<T>.Create(false, e.Message, default(T));
        }
    }
}
