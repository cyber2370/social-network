using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Implementations;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Implementations;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;
using SocialNetworkUwpClient.Business.Factories.Interfaces;

namespace SocialNetworkUwpClient.Business.Factories.Implementations
{
    public class ApiFactory : IApiFactory
    {
        public IAuthApi AuthApi => new AuthApi();

        public ISocialApi SocialApi => new SocialApi();
    }
}
