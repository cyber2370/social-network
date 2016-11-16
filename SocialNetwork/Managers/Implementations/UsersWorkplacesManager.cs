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

        public async Task<IEnumerable<UserWorkplaceModel>> GetAllUsersWorkplaces()
        {
            var usersWorkplaces = await _usersWorkplacesRepository.GetItemsAsync();

            return usersWorkplaces.Select(Mapper.Map<UserWorkplace, UserWorkplaceModel>);
        }

        public async Task<IEnumerable<UserWorkplaceModel>> GetUsersWorkplacesByWorkplaceId(int workplaceId)
        {
            var usersWorkplaces = await _usersWorkplacesRepository.GetItemsAsync(x => x.Where(uw => uw.WorkplaceId == workplaceId));

            return usersWorkplaces.Select(Mapper.Map<UserWorkplace, UserWorkplaceModel>);
        }

        public async Task<IEnumerable<UserWorkplaceModel>> GetUsersWorkplacesByUserId(int userId)
        {
            var usersWorkplaces = await _usersWorkplacesRepository.GetItemsAsync(x => x.Where(uw => uw.UserId == userId));

            return usersWorkplaces.Select(Mapper.Map<UserWorkplace, UserWorkplaceModel>);
        }

        public async Task<UserWorkplaceModel> GetUserWorkplaceById(int userId, int workplaceId)
        {
            var userWorkplace = await _usersWorkplacesRepository.GetItemAsync
                (x => x.Where(uw => uw.UserId == userId && uw.WorkplaceId == workplaceId));

            return Mapper.Map<UserWorkplace, UserWorkplaceModel>(userWorkplace);
        }

        public async Task<UserWorkplaceModel> AddUserWorkplace(UserWorkplaceModel userWorkplace)
        {
            UserWorkplace dbUserWorkplace = Mapper.Map<UserWorkplaceModel, UserWorkplace>(userWorkplace);

            return Mapper.Map<UserWorkplace, UserWorkplaceModel>(await _usersWorkplacesRepository.AddItemAsync(dbUserWorkplace));
        }

        public async Task<UserWorkplaceModel> UpdateUserWorkplace(UserWorkplaceModel userWorkplace)
        {
            UserWorkplace dbUserWorkplace = Mapper.Map<UserWorkplaceModel, UserWorkplace>(userWorkplace);

            return Mapper.Map<UserWorkplace, UserWorkplaceModel>(await _usersWorkplacesRepository.UpdateItemAsync(dbUserWorkplace));
        }

        public async Task<bool> DeleteUserWorkplace(int userId, int workplaceId)
        {
            try
            {
                var userToDelete = Mapper.Map<UserWorkplaceModel, UserWorkplace>(await GetUserWorkplaceById(userId, workplaceId));

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
