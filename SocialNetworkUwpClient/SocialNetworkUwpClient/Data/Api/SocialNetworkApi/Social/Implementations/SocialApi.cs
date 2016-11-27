using System;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Implementations
{
    public class SocialApi : ISocialApi
    {
        private readonly string _apiBaseAddress;

        public SocialApi()
        {
            var apiRouting = new ApiRouting();
            _apiBaseAddress = apiRouting.SocialNetworkApiUrl;
        }

        public Task<User> GetUser()
        {
            return GetRestApi().GetUser();
        }

        public Task<Profile> GetProfile()
        {
            return GetRestApi().GetProfile();
        }

        public Task<Profile> GetProfileById(int id)
        {
            return GetRestApi().GetProfileById(id);
        }

        public Task<Profile> GetProfileOf(int userId)
        {
            return GetRestApi().GetProfileByUserId(userId);
        }

        public Task<Profile> CreateProfile(Profile profile)
        {
            return GetRestApi().CreateProfile(profile);
        }

        public Task<Profile> UpdateProfile(Profile profile)
        {
            return GetRestApi().UpdateProfile(profile);
        }

        private RestApi GetRestApi()
        {
            return new RestApi(new Uri(_apiBaseAddress));
        }
    }
}