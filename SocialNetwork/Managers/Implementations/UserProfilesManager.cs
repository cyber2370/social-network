using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;

namespace Managers.Implementations
{
    internal class UserProfilesManager : ManagerBase, IUserProfilesManager
    {
        private readonly IUserProfilesRepository _userProfilesRepository;
        private readonly ApplicationUserManager _applicationUserManager;

        public UserProfilesManager(
            IUserProfilesRepository usersRepository,
            ApplicationUserManager applicationUserManager)
        {
            _userProfilesRepository = usersRepository;
            _applicationUserManager = applicationUserManager;
        }

        public async Task<IEnumerable<UserProfile>> GetAllUsers()
        {
            return (await _userProfilesRepository.GetItemsAsync())
                .Select(Mapper.Map<UserProfile, UserProfile>);
        }
        public async Task<UserProfile> GetUserProfile(string userId)
        {
            return (await _applicationUserManager.FindByIdAsync(userId)).Profile;
        }

        public async Task<UserProfile> GetUserProfileByEmail(string email)
        {
            return await _userProfilesRepository.GetItemAsync(x => x.Where(u => u.User.Email == email));
        }

        public Task<bool> CheckIfItemExists(string id)
        {
            return _userProfilesRepository.CheckIsItemExists(id);
        }

        public async Task<UserProfile> CreateProfile(UserProfile profileModel)
        {
            return await _userProfilesRepository.AddItemAsync(profileModel);
        }

        public async Task<UserProfile> UpdateProfile(UserProfile profileModel)
        {
            return await _userProfilesRepository.UpdateItemAsync(profileModel);
        }

        public async Task<bool> DeleteProfile(string id)
        {
            try
            {
                await _userProfilesRepository.RemoveItemAsync(id);
                return true;
            }
            catch
            {
                //TODO: Handle exception
                return false;
            }
        }
    }
}
