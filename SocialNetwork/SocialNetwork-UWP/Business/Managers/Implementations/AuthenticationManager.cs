using System.Threading.Tasks;
using SocialNetwork_UWP.Business.Factories.Interfaces;
using SocialNetwork_UWP.Business.Managers.Interfaces;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Interfaces;
using SocialNetwork_UWP.Data.Local.Interfaces;

namespace SocialNetwork_UWP.Business.Managers.Implementations
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly IAuthApi _authApi;

        private readonly IPreferencesService _preferencesService;

        public AuthenticationManager(
            IApiFactory apiFactory,
            IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;

            _authApi = apiFactory.AuthApi;
        }


        public Task GetCurrentUser()
        {
            return _authApi.GetUser();
        }

        public async Task Authorize(string username, string password)
        {
            _preferencesService.SessionInfo = await _authApi.Login(username, password);

            _preferencesService.User = await _authApi.GetUser();
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