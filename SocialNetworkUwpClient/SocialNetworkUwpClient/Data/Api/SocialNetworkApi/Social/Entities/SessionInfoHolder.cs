using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetworkUwpClient.Data.Local.Interfaces;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities
{
    public class SessionInfoHolder
    {
        private readonly IPreferencesService _preferencesService;

        public SessionInfoHolder(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }

        public SessionInfo SessionInfo => _preferencesService.SessionInfo;
       
    }
}
