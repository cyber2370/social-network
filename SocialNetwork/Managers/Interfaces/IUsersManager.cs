using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IUsersManager
    {
        Task<IEnumerable<UserModel>> GetAllUsers();

        Task<UserModel> GetUserById(int id);

        Task<UserModel> AddUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user);

        Task<bool> DeleteUser(int id);
    }
}
