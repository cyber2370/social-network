using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;

namespace Managers.Implementations
{
    internal class UsersWorkplacesManager : ManagerBase, IUsersWorkplacesManager
    {
        private readonly IUsersWorkplacesRepository _usersWorkplacesRepository;

        public UsersWorkplacesManager(IUsersWorkplacesRepository usersWorkplacesRepository)
        {
            _usersWorkplacesRepository = usersWorkplacesRepository;
        }

        public async Task<IEnumerable<UserWorkplace>> GetAllUsersWorkplaces()
        {
            var usersWorkplaces = await _usersWorkplacesRepository.GetItemsAsync();

            return usersWorkplaces.Select(Mapper.Map<UserWorkplace, UserWorkplace>);
        }

        public async Task<IEnumerable<UserWorkplace>> GetUsersWorkplacesByWorkplaceId(int workplaceId)
        {
            var usersWorkplaces = await _usersWorkplacesRepository.GetItemsAsync(x => x.Where(uw => uw.WorkplaceId == workplaceId));

            return usersWorkplaces.Select(Mapper.Map<UserWorkplace, UserWorkplace>);
        }

        public async Task<IEnumerable<UserWorkplace>> GetUsersWorkplacesByUserId(int userId)
        {
            var usersWorkplaces = await _usersWorkplacesRepository.GetItemsAsync(x => x.Where(uw => uw.UserId == userId));

            return usersWorkplaces.Select(Mapper.Map<UserWorkplace, UserWorkplace>);
        }

        public async Task<UserWorkplace> GetUserWorkplaceById(int userId, int workplaceId)
        {
            var userWorkplace = await _usersWorkplacesRepository.GetItemAsync
                (x => x.Where(uw => uw.UserId == userId && uw.WorkplaceId == workplaceId));

            return Mapper.Map<UserWorkplace, UserWorkplace>(userWorkplace);
        }

        public async Task<UserWorkplace> AddUserWorkplace(UserWorkplace userWorkplace)
        {
            UserWorkplace dbUserWorkplace = Mapper.Map<UserWorkplace, UserWorkplace>(userWorkplace);

            return Mapper.Map<UserWorkplace, UserWorkplace>(await _usersWorkplacesRepository.AddItemAsync(dbUserWorkplace));
        }

        public async Task<UserWorkplace> UpdateUserWorkplace(UserWorkplace userWorkplace)
        {
            UserWorkplace dbUserWorkplace = Mapper.Map<UserWorkplace, UserWorkplace>(userWorkplace);

            return Mapper.Map<UserWorkplace, UserWorkplace>(await _usersWorkplacesRepository.UpdateItemAsync(dbUserWorkplace));
        }

        public async Task<bool> DeleteUserWorkplace(int userId, int workplaceId)
        {
            try
            {
                var userToDelete = Mapper.Map<UserWorkplace, UserWorkplace>(await GetUserWorkplaceById(userId, workplaceId));

                await _usersWorkplacesRepository.RemoveItemAsync(userToDelete);

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
