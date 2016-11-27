using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Interfaces;
using SocialNetworkUwpClient.Business.Factories.Interfaces;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;

namespace SocialNetworkUwpClient.Business.Managers.Implementations
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IAuthApi _authApi;
        private readonly ISocialApi _socialApi;

        private readonly IPreferencesService _preferencesService;

        public AuthenticationManager(
            IApiFactory apiFactory,
            IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;

            _socialApi = apiFactory.SocialApi;
            _authApi = apiFactory.AuthApi;
        }


        public Task GetCurrentUser()
        {
            return _socialApi.GetUser();
        }

        public async Task Authorize(string username, string password)
        {
            _preferencesService.SessionInfo = await _authApi.Login(username, password);

            _preferencesService.User = await _socialApi.GetUser();
        }

        public Task Register(string username, string password)
        {
            return _authApi.Register(username, password, password);
        }

        public void Logout()
        {
            _preferencesService.Clear();
        }
    }
}