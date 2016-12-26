using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Business.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;

namespace SocialNetworkUwpClient.Business.Managers.Interfaces
{
    public interface IFriendsManager
    {
        Task<IEnumerable<FriendModel>> GetFriendsOf(string userId);
        Task<IEnumerable<FriendRequest>> GetIncomingFriendRequests();
        Task<IEnumerable<FriendRequest>> GetOutgoingFriendRequests();
        Task<bool> CheckIfFriendsWith(string userId);
        Task<FriendRequest> SendFriendRequestTo(string userId);
        Task<bool> RemoveFriendsLinkingWith(string userId);
    }
}
