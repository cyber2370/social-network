using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Interfaces;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Interfaces;

namespace SocialNetwork_UWP.Business.Factories.Interfaces
{
    public interface IApiFactory
    {
        IAuthApi AuthApi { get; }

        ISocialApi SocialApi { get; }
    }
}
