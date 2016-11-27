using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace SocialNetworkUwpClient.Data.Api.Rest
{
    public class RequestInterceptorBase : IRequestInterceptor
    {
        protected readonly List<KeyValuePair<string, string>> QueryItems;

        public RequestInterceptorBase(params KeyValuePair<string, string>[] queryItems)
        {
            QueryItems = queryItems.ToList();
        }

        public virtual void Intercept(HttpClient httpClient)
        {
            foreach (var queryItem in QueryItems)
            {
                httpClient.DefaultRequestHeaders.Add(queryItem.Key, queryItem.Value);
            }
        }

        public void AddInterceptor(KeyValuePair<string, string> interceptor)
        {
            QueryItems.Add(interceptor);
        }
    }
}
