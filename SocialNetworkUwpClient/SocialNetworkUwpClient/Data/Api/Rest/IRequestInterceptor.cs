using System.Net.Http;

namespace SocialNetworkUwpClient.Data.Api.Rest
{
    public interface IRequestInterceptor
    {
        void Intercept(HttpClient httpClient);
    }
}