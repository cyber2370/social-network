using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface IFriendRequestsManager
    {
        Task<IEnumerable<FriendRequestModel>> GetAllFriendRequests();

        Task<FriendRequestModel> GetFriendRequestById(int id);

        Task<FriendRequestModel> AddFriendRequest(FriendRequestModel friendRequest);

        Task<FriendRequestModel> UpdateFriendRequest(FriendRequestModel friendRequest);

        Task<FriendRequestModel> ConfirmFriendRequest(FriendRequestModel friendRequest);

        Task<bool> DeleteFriendRequest(int id);
    }
}
