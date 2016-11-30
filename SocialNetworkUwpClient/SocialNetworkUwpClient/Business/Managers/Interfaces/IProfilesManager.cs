using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Business.Managers.Interfaces
{
    public interface IProfilesManager
    {
        Task<Profile> GetProfileById(int id);

        Task<Profile> GetCurrentProfile();

        Task<Profile> GetProfileOf(int userId);

        Task<bool> CheckIfProfileExists();

        Task<Profile> CreateProfile(Profile profile);

        Task<Profile> UpdateProfile(Profile profile);
    }
}
