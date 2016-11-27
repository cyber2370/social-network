using System.Threading.Tasks;

namespace SocialNetworkUwpClient.Business.Managers.Interfaces
{
    public interface IAuthenticationManager
    {
        Task Authorize(string username, string password);

        Task Register(string username, string password);

        Task GetCurrentUser();

        void Logout();
    }
}
