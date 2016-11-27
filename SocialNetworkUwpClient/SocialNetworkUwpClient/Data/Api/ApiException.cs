﻿using System;

namespace SocialNetworkUwpClient.Data.Api
{
    public class ApiException : Exception
    {
        public ApiException()
        { }

        public ApiException(string message) : base(message)
        { }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
