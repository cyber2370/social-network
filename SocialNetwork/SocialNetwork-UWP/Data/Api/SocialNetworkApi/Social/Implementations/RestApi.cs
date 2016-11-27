using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using SocialNetwork_UWP.Data.Api.Rest;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Implementations
{
    public class RestApi : RestApiBase
    {
        public RestApi(Uri baseAddress) : base(baseAddress)
        {
            this.AddInterceptor(new RequestInterceptor());
        }

        private class RequestInterceptor : RequestInterceptorBase
        {
            private readonly SessionInfoHolder _sessionInfoHolder;

            public RequestInterceptor()
            {
                _sessionInfoHolder = ServiceLocator.Current.GetInstance<SessionInfoHolder>();
            }

            public override void Intercept(HttpClient httpClient)
            {
                QueryItems.Clear();

                QueryItems.Add(new KeyValuePair<string, string>("Accept", "application/json"));
                QueryItems.Add(new KeyValuePair<string, string>("Accept-Language", "en-US"));
                QueryItems.Add(new KeyValuePair<string, string>("UA-Resolution", "240"));

                var sessionInfo = _sessionInfoHolder.SessionInfo;
                if (sessionInfo != null)
                {
                    QueryItems.Add(new KeyValuePair<string, string>("Authorization", sessionInfo.ToString()));
                }

                base.Intercept(httpClient);
            }
        }

        public Task<User> GetUser()
        {
            return Url("account/user")
                .GetAsync<User>();
        }

        public Task<Profile> GetProfile()
        {
            return Url("account/user")
                .GetAsync<User>();
        }

    }
}
