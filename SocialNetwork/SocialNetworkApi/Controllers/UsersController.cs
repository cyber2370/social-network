using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersManager _usersManager;
        private readonly IFriendRequestsManager _friendRequestsManager;

        public UsersController(
            IUsersManager usersManager,
            IFriendRequestsManager friendRequestsManager)
        {
            _usersManager = usersManager;
            _friendRequestsManager = friendRequestsManager;
        }

        // GET api/<controller>
        public async Task<IEnumerable<FriendModel>> GetFriendsOf(int userId)
        {
            return await _friendRequestsManager.GetFriendsOf(userId);
        }

        // GET api/<controller>/5
        public string GetUser(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}