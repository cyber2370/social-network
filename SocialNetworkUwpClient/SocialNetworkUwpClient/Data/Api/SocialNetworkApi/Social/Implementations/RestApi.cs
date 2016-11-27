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
            return Url("userProfiles")
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

        public Task<Profile> CreateProfile(Profile profile)
        {
            return Url("userProfiles")
                .FormUrlEncoded()
                .Param("name", profile.Name)
                .Param("surname", profile.Surname)
                .Param("sex", profile.Sex)
                .Param("avatarUri", profile.AvatarUri.ToString())
                .Param("birthDate", JsonConvert.SerializeObject(profile.BirthDate))
                .Param("registrationDate", JsonConvert.SerializeObject(profile.RegistrationDate))
                .Param("additionalInformation", profile.AdditionalInformation)
                .Param("status", profile.Status)
                .Param("statusUpdated", JsonConvert.SerializeObject(profile.StatusUpdated))
                .Param("relationshipStatus", profile.RelationshipStatus)
                .PostAsync<Profile>();
        }

        public Task<Profile> UpdateProfile(Profile profile)
        {
            return Url("userProfiles")
                .FormUrlEncoded()
                .Param("id", profile.Id.ToString())
                .Param("name", profile.Name)
                .Param("surname", profile.Surname)
                .Param("sex", profile.Sex)
                .Param("avatarUri", profile.AvatarUri.ToString())
                .Param("birthDate", JsonConvert.SerializeObject(profile.BirthDate))
                .Param("registrationDate", JsonConvert.SerializeObject(profile.RegistrationDate))
                .Param("additionalInformation", profile.AdditionalInformation)
                .Param("status", profile.Status)
                .Param("statusUpdated", JsonConvert.SerializeObject(profile.StatusUpdated))
                .Param("relationshipStatus", profile.RelationshipStatus)
                .PostAsync<Profile>();
        }

    }
}
