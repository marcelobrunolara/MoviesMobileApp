
namespace ML.Framework.Base.Services.Models
{
    public  class Result<T>
    {
        public bool IsValid { get; private set; }
        public string Message { get; private set; } = string.Empty;
        public T Content { get; private set; }
        public int HttpStatusCode { get; set; }

        public Result(bool isValid, string message, T content, int httpStatusCode)
        {
            IsValid = isValid;
            Message = message; 
            Content = content;
            HttpStatusCode = httpStatusCode;
        }

        public Result(bool isValid, string message, T content)
        {
            IsValid = isValid;
            Message = message;
            Content = content;
        }

        public static Result<T> Create(bool isValid, string message, T content, int httpStatusCode)
        {
            return new Result<T>(isValid, message, content, httpStatusCode);
        }

        public static Result<T> Create(bool isValid, string message, T content)
        {
            return new Result<T>(isValid, message, content);
        }
    }
}
