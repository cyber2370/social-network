﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetworkUwpClient.Data.Api.Rest
{
    public class UrlRequestBuilder
    {
        private readonly RestApiBase _restApiBase;
        private readonly string _url;

        private readonly IList<KeyValuePair<string, string>> _queryItems;

        internal UrlRequestBuilder(RestApiBase restApiBase, string url)
        {
            _restApiBase = restApiBase;
            _url = url;

            _queryItems = new List<KeyValuePair<string, string>>();
        }

        public UrlRequestBuilder QueryParam(string key, string value)
        {
            if (value != null)
            {
                _queryItems.Add(new KeyValuePair<string, string>(key, value));
            }

            return this;
        }

        public UrlRequestBuilder QueryParam(string key, int? value)
        {
            return QueryParam(key, value?.ToString());
        }

        public Task<T> GetAsync<T>()
        {
            Request request = CreateRequest();

            return request.Get<T>();
        }

        public Task<T> DeleteAsync<T>()
        {
            Request request = CreateRequest();

            return request.Delete<T>();
        }

        internal PostFormUrlEncodedRequestBuilder FormUrlEncoded()
        {
            return new PostFormUrlEncodedRequestBuilder(this);
        }

        internal Request CreateRequest()
        {
            return new Request(_restApiBase, _url, _queryItems);
        }
    }
}
