using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    public class FriendsController : ApiController
    {
        private readonly IFriendRequestsManager _friendRequestsManager;

        public FriendsController(
            IFriendRequestsManager friendRequestsManager)
        {
            _friendRequestsManager = friendRequestsManager;

        }

        // GET api/<controller>
        [Route("api/users/{id}/friends/")]
        public async Task<IEnumerable<FriendModel>> GetFriendsOf(int id)
        {
            return await _friendRequestsManager.GetFriendsOf(id);
        }

        // GET api/<controller>
        [Route("api/users/{id}/sendedFriendsRequests")]
        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsOf(int id)
        {
            return await _friendRequestsManager.GetFriendRequestsFrom(id);
        }

        // GET api/<controller>
        [Route("api/users/{id}/recievedFriendsRequests")]
        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo(int id)
        {
            return await _friendRequestsManager.GetFriendRequestsTo(id);
        }

        // POST api/<controller>
        [HttpDelete]
        [Route("api/users/{id}/friends/{friendId}")]
        public async Task<bool> RemoveFriends(int id, int friendId)
        {
            return await _friendRequestsManager.DeleteFriendRequest(id, friendId);
        }
    }
}