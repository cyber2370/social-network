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
    internal class UsersManager : ManagerBase, IUsersManager
    {
        private readonly IUsersRepository _usersRepository;

        public UsersManager(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return (await _usersRepository.GetItemsAsync())
                .Select(Mapper.Map<User, UserModel>);
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return Mapper.Map<User, UserModel>(await _usersRepository.GetItemAsync(id));
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            User user = await _usersRepository.GetItemAsync(x => x.Where(u => u.Email == email));

            return Mapper.Map<User, UserModel>(user);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            User dbUser = Mapper.Map<UserModel, User>(user);

            return Mapper.Map<User, UserModel>(await _usersRepository.AddItemAsync(dbUser));
        }

        public async Task<UserModel> UpdateUser(UserModel user)
        {
            User dbUser = Mapper.Map<UserModel, User>(user);

            return Mapper.Map<User, UserModel>(await _usersRepository.UpdateItemAsync(dbUser));
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
