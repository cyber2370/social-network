using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using SocialNetworkUwpClient.Data.Api.Rest;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Implementations
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

                var sessionInfo = _sessionInfoHolder.SessionInfo;
                if (sessionInfo != null)
                {
                    QueryItems.Add(new KeyValuePair<string, string>("Authorization", sessionInfo.ToString()));
                }

                base.Intercept(httpClient);
            }
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            return Url($"userProfiles/users/all")
                .GetAsync<IEnumerable<Profile>>();
        }

        public Task<User> GetUser()
        {
            return Url("account/user")
                .GetAsync<User>();
        }

        public Task<Profile> GetProfile()
        {
            return Url("userProfiles/current")
                .GetAsync<Profile>();
        }

        public Task<Profile> GetProfileById(int id)
        {
            return Url($"userProfiles/{id}")
                .GetAsync<Profile>();
        }

        public Task<Profile> GetProfileByUserId(int id)
        {
            return Url($"userProfiles/users/{id}")
                .GetAsync<Profile>();
        }

        public Task<bool> CheckIfProfileExists()
        {
            return Url($"userProfiles/checkProfileExists")
                .GetAsync<bool>();
        }

        public Task<Profile> CreateProfile(Profile profile)
        {
            return Url("userProfiles")
                .FormUrlEncoded()
                .PostJsonAsync<Profile>(profile);
        }

        public Task<Profile> UpdateProfile(Profile profile)
        {
            return Url("userProfiles")
                .FormUrlEncoded()
                .PutJsonAsync(profile);
        }


        // Workplaces

        public Task<IEnumerable<Workplace>> GetWorkplaces()
        {
            return Url("workplaces")
                .GetAsync<IEnumerable<Workplace>>();
        }

        public Task<Workplace> GetWorkplaceById(int id)
        {
            return Url($"workplaces/{id}")
                .GetAsync<Workplace>();
        }

        public Task<Workplace> CreateWorkplace(Workplace workplace)
        {
            return Url($"workplaces")
                .FormUrlEncoded()
                .PostJsonAsync(workplace);
        }

        public Task<Workplace> UpdateWorkplace(Workplace workplace)
        {
            return Url($"workplaces")
                .FormUrlEncoded()
                .PutJsonAsync(workplace);
        }

        public Task<bool> DeleteWorkplace(int id)
        {
            return Url($"workplaces/{id}")
                .DeleteAsync<bool>();
        }
    }
}
