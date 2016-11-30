using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces
{
    public interface ISocialApi
    {
        Task<User> GetUser();

        Task<Profile> GetProfile();

        Task<Profile> GetProfileById(int id);

        Task<Profile> GetProfileOf(int userId);

        Task<bool> CheckIfProfileExists();

        Task<Profile> CreateProfile(Profile profile);

        Task<Profile> UpdateProfile(Profile profile);

    }
}
