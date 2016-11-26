using System.Threading.Tasks;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;

namespace SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Interfaces
{
    public interface IAuthApi
    {
        Task<UserInfo> GetUserInfo();

        Task<SessionInfo> Login(string username, string password);

        Task Register(string email, string password, string confirmPassword);

        Task ChangePassword(string oldPassword, string newPassword, string confirmPassword);
    }
}
