using System.Net;

namespace Api.Wrapper
{
    public interface IResponse<T>
    {
        T Data { get; set; }
        string[] Errors { get; set; }
        string Message { get; set; }
        HttpStatusCode Status { get; set; }
    }
}