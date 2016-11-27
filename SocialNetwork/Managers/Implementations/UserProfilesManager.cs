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
        private readonly AspNetUserManager _aspNetUserManager;

        public UserProfilesManager(
            IUserProfilesRepository usersRepository,
            AspNetUserManager aspNetUserManager)
        {
            _userProfilesRepository = usersRepository;
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<IEnumerable<UserProfileModel>> GetAllUsers()
        {
            return (await _userProfilesRepository.GetItemsAsync())
                .Select(Mapper.Map<UserProfile, UserProfileModel>);
        }
        public async Task<UserProfileModel> GetUserProfile(int userId)
        {
            var user = await _aspNetUserManager.FindByIdAsync(userId);

            return Mapper.Map<UserProfile, UserProfileModel>(user.Profile);
        }

        public async Task<UserProfileModel> GetProfileById(int id)
        {
            var user = await _userProfilesRepository.GetItemAsync(id);

            return Mapper.Map<UserProfile, UserProfileModel>(user);
        }

        public async Task<UserProfileModel> GetUserProfileByEmail(string email)
        {
            UserProfile user = await _userProfilesRepository.GetItemAsync(x => x.Where(u => u.AspNetUser.Email == email));

            return Mapper.Map<UserProfile, UserProfileModel>(user);
        }

        public async Task<UserProfileModel> CreateProfile(int userId, UserProfileModel profileModel)
        {
            UserProfile profile = Mapper.Map<UserProfileModel, UserProfile>(profileModel);

            var user = await _aspNetUserManager.FindByIdAsync(userId);
            profile.AspNetUser = user;

            return Mapper.Map<UserProfile, UserProfileModel>(await _userProfilesRepository.AddItemAsync(profile));
        }

        public async Task<UserProfileModel> UpdateProfile(UserProfileModel profileModel)
        {
            UserProfile profile = Mapper.Map<UserProfileModel, UserProfile>(profileModel);

            return Mapper.Map<UserProfile, UserProfileModel>(await _userProfilesRepository.UpdateItemAsync(profile));
        }

        public async Task<bool> DeleteProfile(int id)
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
