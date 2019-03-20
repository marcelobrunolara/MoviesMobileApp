using ML.Framework.Base.Servicos.Models;
using System;
using System.Threading.Tasks;

namespace ML.Framework.Base.Servicos.Conector
{
    public class ResultHelper
    {
        public static Result<T> MakeErrorMessage<T>(string errorCode, string reason) 
        {
            string mensagem = string.Join("-", errorCode, reason);
            return Result<T>.Create(false, mensagem, default(T));
        }

        public static Result<T> MakeErrorMessage<T>(string reason) 
        {
            return Result<T>.Create(false, reason, default(T));
        }

        public static Result<T> MakeResponseContentMessage<T>(T responseContent)
        {
            return Result<T>.Create(true, string.Empty, responseContent);
        }

        public static Result<T> MakeExceptionMessage<T>(Exception e)
        {
            return Result<T>.Create(false, e.Message, default(T));
        }
    }
}
