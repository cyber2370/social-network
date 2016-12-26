using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;
using Managers.Models.Friends;

namespace Managers.Interfaces
{
    public interface IFriendRequestsManager
    {
        Task<IEnumerable<FriendRequestModel>> GetAllFriendRequests();

        Task<IEnumerable<FriendModel>> GetFriendsOf(string userId);

        Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo(string userId);

        Task<IEnumerable<FriendRequestModel>> GetFriendRequestsFrom(string userId);

        Task<FriendRequestModel> GetFriendRequestById(string id);

        Task<FriendRequestModel> AddFriendRequest(string senderId, string recipientId);

        Task<FriendRequestModel> UpdateFriendRequest(FriendRequestModel friendRequest);

        Task<FriendRequestModel> ConfirmFriendRequest(string senderId, string recipientId);

        Task<bool> DeleteFriendRequest(string userId, string friendId);
    }
}
