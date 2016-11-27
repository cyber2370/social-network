using System;
using System.Net;
using System.Net.Http;

namespace SocialNetwork_UWP.Data.Api
{
    public class HttpException : Exception
    {
        public HttpException()
        { }

        public HttpException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; set; }

        public HttpRequestMessage RequestMessage { get; set; }
    }
}
