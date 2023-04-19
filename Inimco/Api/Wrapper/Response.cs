using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace Api.Wrapper
{
    public class Response<T> : IResponse<T>
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }
        public string[] Errors { get; set; }
        public T Data { get; set; }

        public Response() { }
        public Response(T data) : this(HttpStatusCode.OK, data) { }
        public Response(HttpStatusCode status, T data) : this(status, data, string.Empty) { }
        public Response(HttpStatusCode status, string errorMessage) : this(status, default, string.Empty, new[] { errorMessage }) { }
        public Response(HttpStatusCode status, string[] errors) : this(status, default, string.Empty, errors) { }
        public Response(HttpStatusCode status, T data, string message) : this(status, data, message, null) { }
        public Response(HttpStatusCode status, T data, string message, string[] errors)
        {
            Status = status;
            Data = data;
            Message = message;
            Errors = errors;
        }
    }
}
