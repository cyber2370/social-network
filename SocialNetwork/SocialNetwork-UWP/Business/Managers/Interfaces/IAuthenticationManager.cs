using System.Threading.Tasks;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;

namespace SocialNetwork_UWP.Business.Managers.Interfaces
{
    public interface IAuthenticationManager
    {
        Task Authorize(string username, string password);

        Task Register(string username, string password);

        Task GetCurrentUser();

        void Logout();
    }
}
