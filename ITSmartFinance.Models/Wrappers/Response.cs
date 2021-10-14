using System;
using System.Collections.Generic;
using System.Text;

namespace ITSmartFinance.Models.Wrappers
{
    public class Response<T>
    {
        public Response()
        { }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message ?? string.Empty;
            Errors = null;
            Data = data;
        }

        public Response(string message, string[] errors = null)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            Data = default(T);
        }

        public Response(string[] errors, string message = null)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            Data = default(T);
        }

        public T Data { get; set; }

        public bool Succeeded { get; set; }

        public string[] Errors { get; set; }

        public string Message { get; set; }
    }

}
