using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;
using DbContext.Entities;
using Managers.Models.Friends;

namespace Managers.Implementations
{
    internal class FriendRequestsManager : ManagerBase, IFriendRequestsManager
    {
        private readonly IFriendRequestsRepository _friendRequestsRepository;
        private readonly IUserProfilesManager _profilesManager;

        public FriendRequestsManager(
            IFriendRequestsRepository friendRequestsRepository,
            IUserProfilesManager profilesManager)
        {
            _friendRequestsRepository = friendRequestsRepository;
            _profilesManager = profilesManager;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetAllFriendRequests()
        {
            return (await _friendRequestsRepository.GetItemsAsync())
                .Select(Mapper.Map<FriendRequest, FriendRequestModel>);
        }

        public async Task<IEnumerable<FriendModel>> GetFriendsOf(string userId)
        {
            var friends = await _friendRequestsRepository.GetItemsAsync
                (x => x.Include(z => z.Confirmer)
                .Include(z => z.Requester)
                .Where(fr => fr.ConfirmedDateTime != null && (fr.ConfirmerUserId == userId || fr.RequesterUserId == userId)));


            return friends.Select(f =>
            {
                bool isCurrentUserRequester = userId == f.RequesterUserId;

                UserProfile friend = Mapper.Map<UserProfile, UserProfile>(isCurrentUserRequester ? f.Confirmer : f.Requester);

                return new FriendModel
                {
                    Id = friend.UserId,
                    Name =  friend.Name,
                    Surname = friend.Surname,
                    Email = friend.User?.Email,
                    AvatarUri = friend.AvatarUri
                };
            });

        }

        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo(string userId)
        {
            var friendRequests = await _friendRequestsRepository.GetItemsAsync
                (x => x.Include(z => z.Confirmer).Include(z => z.Requester).Where(fr => fr.ConfirmedDateTime == null && fr.ConfirmerUserId == userId));

            return friendRequests.Select(Mapper.Map<FriendRequest, FriendRequestModel>);
        }

        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsFrom(string userId)
        {
            var friendRequests = await _friendRequestsRepository.GetItemsAsync
                (x => x.Include(z => z.Confirmer).Include(z => z.Requester).Where(fr => fr.ConfirmedDateTime == null && fr.RequesterUserId == userId));

            return friendRequests.Select(Mapper.Map<FriendRequest, FriendRequestModel>);
        }

        public async Task<FriendRequestModel> GetFriendRequestById(int id)
        {
            FriendRequest dbFriendRequest = await _friendRequestsRepository.GetItemAsync(id);

            return Mapper.Map<FriendRequest, FriendRequestModel>(dbFriendRequest);
        }

        [HttpPost]
        public async Task<FriendRequestModel> AddFriendRequest(string senderId, string recipientId)
        {
            var sender = await _profilesManager.GetUserProfile(senderId);
            var confirmer = await _profilesManager.GetUserProfile(recipientId);

            FriendRequest friendRequest = new FriendRequest
            {
                RequesterUserId = sender.UserId,
                ConfirmerUserId = confirmer.UserId,
                RequestedDateTime = DateTime.Now
            };

            var req = await _friendRequestsRepository.AddItemAsync(friendRequest);

            return Mapper.Map<FriendRequest, FriendRequestModel>(req);
        }

        public async Task<FriendRequestModel> UpdateFriendRequest(FriendRequestModel friendRequest)
        {
            FriendRequest dbFriendRequest = Mapper.Map<FriendRequestModel, FriendRequest>(friendRequest);

            return Mapper.Map<FriendRequest, FriendRequestModel>(await _friendRequestsRepository.UpdateItemAsync(dbFriendRequest));
        }

        public async Task<FriendRequestModel> ConfirmFriendRequest(string senderId, string recipientId)
        {
            var friendRequest = await _friendRequestsRepository.GetItemAsync(
                    x => x.Where(fr => fr.ConfirmerUserId == recipientId && senderId == fr.RequesterUserId));

            friendRequest.ConfirmedDateTime = DateTime.Now;

            return await UpdateFriendRequest(Mapper.Map<FriendRequest, FriendRequestModel>(friendRequest));
        }

        public async Task<bool> DeleteFriendRequest(string userId, string friendId)
        {
            try
            {
                FriendRequest friendRequest = await _friendRequestsRepository.GetItemAsync
                (x => x.Where(fr => (fr.RequesterUserId == userId && fr.ConfirmerUserId == friendId)
                                    || (fr.RequesterUserId == friendId && fr.ConfirmerUserId == userId)));


                await _friendRequestsRepository.RemoveItemAsync(friendRequest);

                return true;
            }
            catch
            {
                //TODO: Handle exception
                return false;
            }
        }
    }
}
