namespace Jumify.Application.APIWrapper
{
    public class ResponseWrapper<T>
    {
        public bool IsSuccess { get; init; }
        public string Message { get; init; } = string.Empty;
        public T Data { get; init; }
        public static ResponseWrapper<T> Success(string message = "Operation Success", T data = default)
        {
            return new ResponseWrapper<T>
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }
        public static ResponseWrapper<T> Failure(string message = "Operation Failed")
        {
            return new ResponseWrapper<T>
            {
                IsSuccess = false,
                Message = message
            };
        }
    }
}
