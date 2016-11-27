using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces
{
    public interface ISocialApi
    {
        Task<User> GetUser();

        Task<Profile> GetProfile();

        Task<Profile> GetProfileOf(int userId);

        Task<Profile> CreateProfile(Profile profile);

        Task<Profile> UpdateProfile(Profile profile);

    }
}
