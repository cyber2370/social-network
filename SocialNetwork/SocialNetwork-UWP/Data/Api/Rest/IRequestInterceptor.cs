using System.Net.Http;

namespace SocialNetwork_UWP.Data.Api.Rest
{
    public interface IRequestInterceptor
    {
        void Intercept(HttpClient httpClient);
    }
}