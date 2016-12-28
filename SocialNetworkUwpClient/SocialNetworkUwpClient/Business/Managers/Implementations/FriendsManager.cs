using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Business.Entities;
using SocialNetworkUwpClient.Business.Factories.Interfaces;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;

namespace SocialNetworkUwpClient.Business.Managers.Implementations
{
    public class FriendsManager : IFriendsManager
    {
        private readonly ISocialApi _socialApi;
        private readonly IPreferencesService _preferencesService;

        public FriendsManager(IApiFactory apiFactory, IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
            _socialApi = apiFactory.SocialApi;
        }

        public async Task<IEnumerable<FriendModel>> GetFriendsOf(string userId)
        {
            return (await _socialApi.GetFriendsOf(userId)).Select(x => new FriendModel
            {
                Id = x.UserId,
                Surname = x.Surname,
                Name = x.Name,
                AvatarUri = x.AvatarUri
            });
        }

        public Task<IEnumerable<FriendRequest>> GetIncomingFriendRequests()
        {
            return _socialApi.GetIncomingFriendRequests();
        }

        public Task<IEnumerable<FriendRequest>> GetOutgoingFriendRequests()
        {
            return _socialApi.GetOutgoingFriendRequests();
        }

        public async Task<FriendRequest> CheckIfFriendsWith(string userId)
        {
            var incoming = await GetIncomingFriendRequests();

            FriendRequest request = incoming.FirstOrDefault(x => 
            (x.RequesterUserId == _preferencesService.User.Id && x.ConfirmerUserId == userId)
            || (x.RequesterUserId == userId && x.ConfirmerUserId == _preferencesService.User.Id));

            if (request == null)
            {
                var outgoing = await GetOutgoingFriendRequests();
                request = outgoing.FirstOrDefault(x =>
                (x.RequesterUserId == _preferencesService.User.Id && x.ConfirmerUserId == userId)
                || (x.RequesterUserId == userId && x.ConfirmerUserId == _preferencesService.User.Id));
            }

            return request;

        }

        public Task<bool> ConfirmFriendRequests(string friendId)
        {
            return _socialApi.ConfirmFriendRequest(friendId);
        }

        public Task<FriendRequest> SendFriendRequestTo(string userId)
        {
            return _socialApi.SendFriendRequestTo(userId);
        }

        public Task<bool> RemoveFriendsLinkingWith(string userId)
        {
            return _socialApi.RemoveFriends(userId);
        }
    }
}
