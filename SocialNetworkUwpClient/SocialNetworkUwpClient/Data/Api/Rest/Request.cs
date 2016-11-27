using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SocialNetworkUwpClient.Data.Api.Rest
{
    internal class Request
    {
        private readonly RestApiBase _restApiBase;
        private readonly string _url;

        private readonly IList<KeyValuePair<string, string>> _queryItems;

        public Request(RestApiBase restApiBase, string url, IList<KeyValuePair<string, string>> queryItems)
        {
            _restApiBase = restApiBase;
            _url = url;
            _queryItems = queryItems;
        }

        internal async Task<T> Get<T>()
        {
            using (var httpClient = CreateHttpClient())
            {
                _restApiBase.CallInterceptors(httpClient);

                var response = CheckResponse(await httpClient.GetAsync(PrepareUrl()));

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        internal async Task<T> Delete<T>()
        {
            using (var httpClient = CreateHttpClient())
            {
                _restApiBase.CallInterceptors(httpClient);

                var response = CheckResponse(await httpClient.DeleteAsync(PrepareUrl()));

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        internal async Task<T> Put<T>(IList<KeyValuePair<string, string>> @params)
        {
            using (var httpClient = CreateHttpClient())
            {
                _restApiBase.CallInterceptors(httpClient);

                var response = CheckResponse(await httpClient.PutAsync(_url, new FormUrlEncodedContent(@params)));

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        internal async Task Put(IList<KeyValuePair<string, string>> @params)
        {
            using (var httpClient = CreateHttpClient())
            {
                _restApiBase.CallInterceptors(httpClient);

                CheckResponse(await httpClient.PutAsync(_url, new FormUrlEncodedContent(@params)));
            }
        }

        internal async Task<T> PostFormUrlEncoded<T>(IList<KeyValuePair<string, string>> @params)
        {
            using (var httpClient = CreateHttpClient())
            {
                _restApiBase.CallInterceptors(httpClient);

                var response = CheckResponse(await httpClient.PostAsync(_url, new FormUrlEncodedContent(@params)));

                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
        }

        internal async Task PostFormUrlEncoded(IList<KeyValuePair<string, string>> @params)
        {
            using (var httpClient = CreateHttpClient())
            {
                _restApiBase.CallInterceptors(httpClient);

                CheckResponse(await httpClient.PostAsync(_url, new FormUrlEncodedContent(@params)));
            }
        }

        private HttpResponseMessage CheckResponse(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpException(response.ReasonPhrase, response.StatusCode);
            }

            return response;
        }

        private HttpClient CreateHttpClient()
        {
            return new HttpClient
            {
                BaseAddress = _restApiBase.BaseAddress
            };
        }
        
        private string PrepareUrl()
        {
            StringBuilder sb = new StringBuilder(_url);

            if (_queryItems.Count > 0)
            {
                sb.Append('?').Append(string.Join("&", _queryItems.Select(it => $"{it.Key}={it.Value}")));
            }

            return sb.ToString();
        }
    }
}
