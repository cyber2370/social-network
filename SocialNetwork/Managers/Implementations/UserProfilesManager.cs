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
        private readonly IUserProfilesRepository _usersRepository;
        private readonly AspNetUserManager _aspNetUserManager;

        public UserProfilesManager(
            IUserProfilesRepository usersRepository,
            AspNetUserManager aspNetUserManager)
        {
            _usersRepository = usersRepository;
            _aspNetUserManager = aspNetUserManager;
        }

        public async Task<IEnumerable<UserProfileModel>> GetAllUsers()
        {
            return (await _usersRepository.GetItemsAsync())
                .Select(Mapper.Map<UserProfile, UserProfileModel>);
        }
        public async Task<UserProfileModel> GetUserProfile(int userId)
        {
            var user = await _aspNetUserManager.FindByIdAsync(userId);

            return Mapper.Map<UserProfile, UserProfileModel>(user.Profile);
        }

        public async Task<UserProfileModel> GetUserProfileById(int id)
        {
            var user = await _usersRepository.GetItemAsync(id);

            return Mapper.Map<UserProfile, UserProfileModel>(user);
        }

        public async Task<UserProfileModel> GetUserProfileByEmail(string email)
        {
            UserProfile user = await _usersRepository.GetItemAsync(x => x.Where(u => u.AspNetUser.Email == email));

            return Mapper.Map<UserProfile, UserProfileModel>(user);
        }

        public async Task<UserProfileModel> CreateProfile(int userId, UserProfileModel profileModel)
        {
            UserProfile profile = Mapper.Map<UserProfileModel, UserProfile>(profileModel);

            var user = await _aspNetUserManager.FindByIdAsync(userId);
            profile.AspNetUser = user;

            return Mapper.Map<UserProfile, UserProfileModel>(await _usersRepository.AddItemAsync(profile));
        }

        public async Task<UserProfileModel> UpdateProfile(UserProfileModel profileModel)
        {
            UserProfile profile = Mapper.Map<UserProfileModel, UserProfile>(profileModel);

            return Mapper.Map<UserProfile, UserProfileModel>(await _usersRepository.UpdateItemAsync(profile));
        }

        public async Task<bool> DeleteProfile(int id)
        {
            try
            {
                await _usersRepository.RemoveItemAsync(id);
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
