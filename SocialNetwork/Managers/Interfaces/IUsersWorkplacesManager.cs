using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IUsersWorkplacesManager
    {
        Task<IEnumerable<UserWorkplaceModel>> GetAllUsersWorkplaces();

        Task<IEnumerable<UserWorkplaceModel>> GetUsersWorkplacesByWorkplaceId(int workplaceId);

        Task<IEnumerable<UserWorkplaceModel>> GetUsersWorkplacesByUserId(int userId);

        Task<UserWorkplaceModel> GetUserWorkplaceById(int userId, int workplaceId);

        Task<UserWorkplaceModel> AddUserWorkplace(UserWorkplaceModel userWorkplace);

        Task<UserWorkplaceModel> UpdateUserWorkplace(UserWorkplaceModel userWorkplace);

        Task<bool> DeleteUserWorkplace(int userId, int workplaceId);
    }
}
