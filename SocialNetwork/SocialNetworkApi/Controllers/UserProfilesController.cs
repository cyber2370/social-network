using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Managers;
using Managers.Interfaces;
using Managers.Models;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("userProfiles")]
    public class UserProfilesController : ApiController
    {
        private readonly IUserProfilesManager _userProfilesManager;
        private readonly IFriendRequestsManager _friendRequestsManager;
        private readonly IMessagesManager _messagesManager;
        private readonly IUsersWorkplacesManager _usersWorkplacesManager;

        public UserProfilesController(
            IUserProfilesManager usersManager,
            IFriendRequestsManager friendRequestsManager,
            IMessagesManager messagesManager,
            IUsersWorkplacesManager usersWorkplacesManager)
        {
            _userProfilesManager = usersManager;
            _friendRequestsManager = friendRequestsManager;
            _messagesManager = messagesManager;
            _usersWorkplacesManager = usersWorkplacesManager;
        }

        #region UsersOperations

        [HttpGet]
        public async Task<UserProfileModel> GetUserProfile()
        {
            int userId = GetCurrentUserId();

            return await _userProfilesManager.GetUserProfile(userId);
        }

        [HttpGet]
        public async Task<UserProfileModel> GetUserProfileById(int id)
        {
            return await _userProfilesManager.GetUserProfileById(id);
        }

        [HttpPost]
        public async Task<UserProfileModel> CreateProfile([FromBody]UserProfileModel model)
        {
            int userId = GetCurrentUserId();

            return await _userProfilesManager.CreateProfile(userId, model);
        }
        
        [HttpPut]
        public async Task<UserProfileModel> UpdateProfile([FromBody]UserProfileModel model)
        {
            return await _userProfilesManager.UpdateProfile(model);
        }

        [HttpDelete]
        public async Task<bool> DeleteProfile(int id)
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
        public async Task<IEnumerable<UserWorkplaceModel>> GetUserWorkplaces()
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

        private int GetCurrentUserId()
        {
            return RequestContext.Principal.Identity.GetUserIdIntPk();
        }
    }
}