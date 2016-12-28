using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces
{
    public interface ISocialApi
    {
        Task<User> GetUser();
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile();
        Task<Profile> GetProfileById(string id);
        Task<Profile> GetProfileOf(string userId);
        Task<bool> CheckIfProfileExists();
        Task<Profile> CreateProfile(Profile profile);
        Task<Profile> UpdateProfile(Profile profile);

        Task<IEnumerable<Profile>> GetFriendsOf(string userId);
        Task<IEnumerable<FriendRequest>> GetOutgoingFriendRequests();
        Task<IEnumerable<FriendRequest>> GetIncomingFriendRequests();
        Task<bool> ConfirmFriendRequest(string friendId);
        Task<FriendRequest> SendFriendRequestTo(string userId);
        Task<bool> RemoveFriends(string userId);

        Task<IEnumerable<Workplace>> GetWorkplaces();
        Task<Workplace> GetWorkplaceById(int id);
        Task<Workplace> CreateWorkplace(Workplace workplace);
        Task<Workplace> UpdateWorkplace(Workplace workplace);
        Task DeleteWorkplace(int id);


        Task<UsersReport> GetUsersReport();
    }
}
