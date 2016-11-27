using System.Threading.Tasks;
using SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetwork_UWP.Data.Api.SocialNetworkApi.Social.Interfaces
{
    public interface ISocialApi
    {
        Task<User> GetUser();

        Task<Profile> GetProfile();

        Task<Profile> GetProfileOf(int userId);

        Task<Profile> CreateProfile(Profile profile);


    }
}
