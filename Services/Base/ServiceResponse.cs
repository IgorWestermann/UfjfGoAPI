namespace UfjfGoAPI.Services.Base
{
    public class ServiceResponse<T>
    {
        public bool Success { get; private set; }
        public T? Result { get; private set; }
        public string Message { get; private set; }

        public ServiceResponse(T result)
        {
            Success = true;
            Message = string.Empty;
            Result = result;
        }
        public ServiceResponse(string errorMessage)
        {
            Success = false;
            Message = errorMessage;
            Result = default;
        }
    }
}
