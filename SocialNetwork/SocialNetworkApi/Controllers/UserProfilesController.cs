﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    [RoutePrefix("users")]
    public class UserProfilesController : ApiController
    {
        private readonly IUserProfilesManager _usersManager;
        private readonly IFriendRequestsManager _friendRequestsManager;
        private readonly IMessagesManager _messagesManager;
        private readonly IUsersWorkplacesManager _usersWorkplacesManager;

        public UserProfilesController(
            IUserProfilesManager usersManager,
            IFriendRequestsManager friendRequestsManager,
            IMessagesManager messagesManager,
            IUsersWorkplacesManager usersWorkplacesManager)
        {
            _usersManager = usersManager;
            _friendRequestsManager = friendRequestsManager;
            _messagesManager = messagesManager;
            _usersWorkplacesManager = usersWorkplacesManager;
        }

        #region UsersOperations

        [HttpGet]
        public async Task<UserModel> GetUser(string email)
        {
            return await _usersManager.GetUserByEmail(email);
        }

        [HttpPost]
        public async Task<UserModel> RegisterUser([FromBody]UserModel model)
        {
            return await _usersManager.AddUser(model);
        }

        [HttpPut]
        public async Task<UserModel> UpdateUserInformation(int id, [FromBody]UserModel model)
        {
            model.Id = id;

            return await _usersManager.UpdateUser(model);
        }

        [HttpDelete]
        public async Task<bool> DeleteUser(int id)
        {
            return await _usersManager.DeleteUser(id);
        }

        #endregion

        #region FriendsOperations

        [Route("{userId}/friends/")]
        public async Task<IEnumerable<FriendModel>> GetFriendsOf(int userId)
        {
            return await _friendRequestsManager.GetFriendsOf(userId);
        }
        
        [Route("{userId}/sendedFriendsRequests")]
        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsOf(int userId)
        {
            return await _friendRequestsManager.GetFriendRequestsFrom(userId);
        }
        
        [Route("{userId}/recievedFriendsRequests")]
        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo(int userId)
        {
            return await _friendRequestsManager.GetFriendRequestsTo(userId);
        }
        
        [HttpDelete]
        [Route("{userId}/friends/{friendId}")]
        public async Task<bool> RemoveFriends(int userId, int friendId)
        {
            return await _friendRequestsManager.DeleteFriendRequest(userId, friendId);
        }

        #endregion

        #region MessagesOperations

        [HttpGet]
        [Route("{userId}/messagesWith/{opponentId}")]
        public async Task<IEnumerable<MessageModel>> GetUserMessagesWith(int userId, int opponentId)
        {
            return await _messagesManager.GetMessagesBetween(userId, opponentId);
        }

        [HttpGet]
        [Route("{userId}/messages")]
        public async Task<IEnumerable<MessageModel>> GetUserMessages(int userId)
        {
            return await _messagesManager.GetMessagesOf(userId);
        }

        #endregion

        #region WorkplacesOperations

        [HttpGet]
        [Route("{userId}/workplaces/")]
        public async Task<IEnumerable<UserWorkplaceModel>> GetUserWorkplaces(int userId)
        {
            return await _usersWorkplacesManager.GetUsersWorkplacesByUserId(userId);
        }

        [HttpDelete]
        [Route("{userId}/workplaces/{workplaceId}")]
        public async Task<bool> RemoveWorkplaceFromUser(int userId, int workplaceId)
        {
            return await _usersWorkplacesManager.DeleteUserWorkplace(userId, workplaceId);
        }

        #endregion
    }
}