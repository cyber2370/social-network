using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;
using Managers.Models.Friends;

namespace Managers.Interfaces
{
    public interface IFriendRequestsManager
    {
        Task<IEnumerable<FriendRequestModel>> GetAllFriendRequests();

        Task<IEnumerable<FriendModel>> GetFriendsOf(int userId);

        Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo(int userId);

        Task<IEnumerable<FriendRequestModel>> GetFriendRequestsFrom(int userId);

        Task<FriendRequestModel> GetFriendRequestById(int id);

        Task<FriendRequestModel> AddFriendRequest(FriendRequestModel friendRequest);

        Task<FriendRequestModel> UpdateFriendRequest(FriendRequestModel friendRequest);

        Task<FriendRequestModel> ConfirmFriendRequest(FriendRequestModel friendRequest);

        Task<bool> DeleteFriendRequest(int userId, int friendId);
    }
}
