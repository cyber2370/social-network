using System;
using System.Net;
using System.Net.Http;

namespace SocialNetworkUwpClient.Data.Api
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
