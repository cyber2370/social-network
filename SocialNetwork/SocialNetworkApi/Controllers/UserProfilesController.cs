using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DbContext.Entities;
using Managers.Implementations;
using Managers.Interfaces;
using Managers.Models;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("userProfiles")]
    public class UserProfilesController : ApiControllerBase
    {
        private readonly IUserProfilesManager _userProfilesManager;
        private readonly IFriendRequestsManager _friendRequestsManager;
        private readonly IMessagesManager _messagesManager;
        private readonly IUsersWorkplacesManager _usersWorkplacesManager;
        private readonly ApplicationUserManager _applicationUserManager;

        public UserProfilesController(
            IUserProfilesManager usersManager,
            IFriendRequestsManager friendRequestsManager,
            IMessagesManager messagesManager,
            IUsersWorkplacesManager usersWorkplacesManager,
            ApplicationUserManager aspNetUserManager)
        {
            _userProfilesManager = usersManager;
            _friendRequestsManager = friendRequestsManager;
            _messagesManager = messagesManager;
            _usersWorkplacesManager = usersWorkplacesManager;
            _applicationUserManager = aspNetUserManager;
        }

        #region UsersOperations

        [HttpGet]
        public async Task<UserProfile> GetProfile()
        {
            var user = await GetCurrentUser(_applicationUserManager);

            if (user.Profile == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return await _userProfilesManager.GetUserProfile(user.Profile.UserId);
        }
        
        [HttpGet]
        public async Task<UserProfile> GetProfileById(string id)
        {
            return await _userProfilesManager.GetUserProfile(id);
        }

        [HttpGet]
        [Route("users/{userId}")]
        public async Task<UserProfile> GetUserProfile(string userId)
        {
            return await _userProfilesManager.GetUserProfile(userId);
        }

        [HttpGet]
        [Route("users/checkProfileExists")]
        public async Task<bool> CheckIfProfileExists()
        {
            var currentUser = await GetCurrentUser(_applicationUserManager);

            return await _userProfilesManager.CheckIfItemExists(currentUser.Id);
        }

        [HttpPost]
        public async Task<UserProfile> CreateProfile([FromBody]UserProfile model)
        {
            try
            {
                var user = await GetCurrentUser(_applicationUserManager);

                model.RegistrationDate = DateTime.Now;
                model.StatusUpdated = DateTime.Now;
                model.UserId = user.Id;
                model.IncomingFriendRequests = new List<FriendRequest>();
                model.OutgoingFriendRequests = new List<FriendRequest>();

                return await _userProfilesManager.CreateProfile(model);
            }
            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<UserProfile> UpdateProfile([FromBody]UserProfile model)
        {
            return await _userProfilesManager.UpdateProfile(model);
        }

        [HttpDelete]
        public async Task<bool> DeleteProfile(string id)
        {
            return await _userProfilesManager.DeleteProfile(id);
        }

        #endregion

        #region FriendsOperations

        [Route("{userId}/friends/")]
        public async Task<IEnumerable<FriendModel>> GetFriendsOf()
        {
            int userId = 1;

            return await _friendRequestsManager.GetFriendsOf(userId);
        }
        
        [Route("{userId}/sendedFriendsRequests")]
        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsOf()
        {
            int userId = 1;

            return await _friendRequestsManager.GetFriendRequestsFrom(userId);
        }
        
        [Route("{userId}/recievedFriendsRequests")]
        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo()
        {
            int userId = 1;

            return await _friendRequestsManager.GetFriendRequestsTo(userId);
        }
        
        [HttpDelete]
        [Route("{userId}/friends/{friendId}")]
        public async Task<bool> RemoveFriends(int friendId)
        {
            int userId = 1;

            return await _friendRequestsManager.DeleteFriendRequest(userId, friendId);
        }

        #endregion

        #region MessagesOperations

        [HttpGet]
        [Route("{userId}/messagesWith/{opponentId}")]
        public async Task<IEnumerable<MessageModel>> GetUserMessagesWith(int opponentId)
        {
            int userId = 1;

            return await _messagesManager.GetMessagesBetween(userId, opponentId);
        }

        [HttpGet]
        [Route("{userId}/messages")]
        public async Task<IEnumerable<MessageModel>> GetUserMessages()
        {
            int userId = 1;

            return await _messagesManager.GetMessagesOf(userId);
        }

        #endregion

        #region WorkplacesOperations

        [HttpGet]
        [Route("{userId}/workplaces/")]
        public async Task<IEnumerable<UserWorkplace>> GetUserWorkplaces()
        {
            int userId = 1;

            return await _usersWorkplacesManager.GetUsersWorkplacesByUserId(userId);
        }

        [HttpDelete]
        [Route("{userId}/workplaces/{workplaceId}")]
        public async Task<bool> RemoveWorkplaceFromUser(int workplaceId)
        {
            int userId = 1;

            return await _usersWorkplacesManager.DeleteUserWorkplace(userId, workplaceId);
        }

        #endregion
    }
}