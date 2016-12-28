using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Business.Factories.Interfaces;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;

namespace SocialNetworkUwpClient.Business.Managers.Implementations
{
    public class ProfilesManager : IProfilesManager
    {
        private readonly ISocialApi _socialApi;

        public ProfilesManager(IApiFactory apiFactory)
        {
            _socialApi = apiFactory.SocialApi;
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
           return _socialApi.GetProfiles();
        }

        public Task<Profile> GetProfileById(string id)
        {
            return _socialApi.GetProfileById(id);
        }

        public Task<Profile> GetCurrentProfile()
        {
            return _socialApi.GetProfile();
        }

        public Task<Profile> GetProfileOf(string id)
        {
            return _socialApi.GetProfileOf(id);
        }

        public Task<bool> CheckIfProfileExists()
        {
            return _socialApi.CheckIfProfileExists();
        }

        public Task<Profile> CreateProfile(Profile profile)
        {
            return _socialApi.CreateProfile(profile);
        }

        public Task<Profile> UpdateProfile(Profile profile)
        {
            return _socialApi.UpdateProfile(profile);
        }
    }
}