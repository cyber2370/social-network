using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;

namespace SocialNetworkUwpClient.Business.Factories.Interfaces
{
    public interface IApiFactory
    {
        IAuthApi AuthApi { get; }

        ISocialApi SocialApi { get; }
    }
}
