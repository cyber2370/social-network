using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Data.Local.Interfaces;

namespace SocialNetworkUwpClient.Data.Api.Rest
{
    public class RestApiBase
    {
        private readonly IPreferencesService _preferencesService;

        private readonly IList<IRequestInterceptor> _requestInterceptors;
        private readonly Uri _baseAddress;

        public RestApiBase(Uri baseAddress)
        {
            _requestInterceptors = new List<IRequestInterceptor>();
            _baseAddress = baseAddress;

            _preferencesService = ServiceLocator.Current.GetInstance<IPreferencesService>();
        }

        public Uri BaseAddress
        {
            get
            {
                return _baseAddress;
            }
        }
        
        protected string QueryParam(string property, string value)
        {
            return $"{property}={value}";
        }
        
        internal void CallInterceptors(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();

            foreach (var requestInterceptor in _requestInterceptors)
            {
                requestInterceptor.Intercept(httpClient);
            }
        }

        protected UrlRequestBuilder Url(string url)
        {
            return new UrlRequestBuilder(this, url);
        }
        
        public void AddInterceptor(IRequestInterceptor requestInterceptor)
        {
            _requestInterceptors.Add(requestInterceptor);
        }   
    }
}
