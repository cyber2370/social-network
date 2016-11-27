using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IUserProfilesManager
    {
        Task<IEnumerable<UserProfileModel>> GetAllUsers();

        Task<UserProfileModel> GetUserProfile(int userId);

        Task<UserProfileModel> GetUserProfileById(int id);

        Task<UserProfileModel> GetUserProfileByEmail(string email);

        Task<UserProfileModel> CreateProfile(int aspNetUserId, UserProfileModel profile);

        Task<UserProfileModel> UpdateProfile(UserProfileModel user);

        Task<bool> DeleteProfile(int id);
    }
}
