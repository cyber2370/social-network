using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext.Entities;

namespace Managers.Interfaces
{
    public interface IUsersWorkplacesManager
    {
        Task<IEnumerable<UserWorkplace>> GetAllUsersWorkplaces();

        Task<IEnumerable<UserWorkplace>> GetUsersWorkplacesByWorkplaceId(int workplaceId);

        Task<IEnumerable<UserWorkplace>> GetUsersWorkplacesByUserId(string userId);

        Task<UserWorkplace> GetUserWorkplaceById(string userId, int workplaceId);

        Task<UserWorkplace> AddUserWorkplace(UserWorkplace userWorkplace);

        Task<UserWorkplace> UpdateUserWorkplace(UserWorkplace userWorkplace);

        Task<bool> DeleteUserWorkplace(string userId, int workplaceId);
    }
}
