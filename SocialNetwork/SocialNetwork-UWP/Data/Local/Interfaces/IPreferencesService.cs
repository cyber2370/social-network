using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetwork_UWP.Data.Local.Interfaces
{
    public interface IPreferencesService
    {
        SessionInfo SessionInfo { get; set; }

        User User { get; set; }

        bool IsLoggedIn { get; }

        void Clear();
    }
}
