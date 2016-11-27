using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Entities;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Interfaces
{
    public interface IAuthApi
    {
        Task<SessionInfo> Login(string username, string password);

        Task Register(string email, string password, string confirmPassword);

        Task ChangePassword(string oldPassword, string newPassword, string confirmPassword);
    }
}
