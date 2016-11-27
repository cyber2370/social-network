using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Data.Local.Interfaces
{
    public interface IPreferencesService
    {
        SessionInfo SessionInfo { get; set; }

        User User { get; set; }

        bool IsLoggedIn { get; }

        void Clear();
    }
}
