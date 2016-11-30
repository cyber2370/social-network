using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext.Entities;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IUserProfilesManager
    {
        Task<IEnumerable<UserProfile>> GetAllUsers();

        Task<UserProfile> GetUserProfile(string userId);

        Task<UserProfile> GetUserProfileByEmail(string email);

        Task<bool> CheckIfItemExists(string id);

        Task<UserProfile> CreateProfile(UserProfile profile);

        Task<UserProfile> UpdateProfile(UserProfile user);

        Task<bool> DeleteProfile(string id);
    }
}
