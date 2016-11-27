using System.Threading.Tasks;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Interfaces
{
    public interface IAuthApi
    {
        Task<SessionInfo> Login(string username, string password);

        Task Register(string email, string password, string confirmPassword);

        Task ChangePassword(string oldPassword, string newPassword, string confirmPassword);
    }
}
