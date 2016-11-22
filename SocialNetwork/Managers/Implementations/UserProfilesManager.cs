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

        public UserProfilesManager(IUserProfilesRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return (await _usersRepository.GetItemsAsync())
                .Select(Mapper.Map<UserProfile, UserModel>);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var user = await _usersRepository.GetItemAsync(id);

            return Mapper.Map<UserProfile, UserModel>(user);
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            UserProfile user = await _usersRepository.GetItemAsync(x => x.Where(u => u.Email == email));

            return Mapper.Map<UserProfile, UserModel>(user);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            UserProfile dbUser = Mapper.Map<UserModel, UserProfile>(user);

            return Mapper.Map<UserProfile, UserModel>(await _usersRepository.AddItemAsync(dbUser));
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            UserProfile dbUser = Mapper.Map<UserModel, UserProfile>(user);

            return Mapper.Map<UserProfile, UserModel>(await _usersRepository.UpdateItemAsync(dbUser));
        }

        public async Task<bool> DeleteUser(int id)
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
