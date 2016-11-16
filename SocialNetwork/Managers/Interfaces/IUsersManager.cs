using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IUsersManager
    {
        Task<IEnumerable<UserModel>> GetAllUsers();

        Task<UserModel> GetUserByEmail(string email);

        Task<UserModel> AddUser(UserModel user);

        Task<UserModel> UpdateUser(UserModel user);

        Task<bool> DeleteUser(string email);
    }
}
