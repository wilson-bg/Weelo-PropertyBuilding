namespace Weelo.Core.Wrappers
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }

        public Response()
        {
        }
        public Response(T Result, string message = null)
        {
            this.Succeeded = true;
            this.Message = message;
            this.Data = Result;
        }
        public Response(string message)
        {
            this.Succeeded = false;
            this.Message = message;
        }

    }
}
