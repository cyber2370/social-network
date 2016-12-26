using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public FriendRequestsManager(IFriendRequestsRepository friendRequestsRepository)
        {
            _friendRequestsRepository = friendRequestsRepository;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetAllFriendRequests()
        {
            return (await _friendRequestsRepository.GetItemsAsync())
                .Select(Mapper.Map<FriendRequest, FriendRequestModel>);
        }

        public async Task<IEnumerable<FriendModel>> GetFriendsOf(string userId)
        {
            var friends = await _friendRequestsRepository.GetItemsAsync
                (x => x.Where(fr => fr.ConfirmedDateTime != null && (fr.ConfirmerId == userId || fr.RequesterId == userId)));


            return friends.Select(f =>
            {
                bool isCurrentUserRequester = userId == f.RequesterId;

                UserProfile friend = Mapper.Map<UserProfile, UserProfile>(isCurrentUserRequester ? f.Confirmer : f.Requester);

                return Mapper.Map<UserProfile, FriendModel>(friend);
            });

        }

        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsTo(string userId)
        {
            var friendRequests = await _friendRequestsRepository.GetItemsAsync
                (x => x.Where(fr => fr.ConfirmedDateTime == null && fr.ConfirmerId == userId));

            return friendRequests.Select(Mapper.Map<FriendRequest, FriendRequestModel>);
        }

        public async Task<IEnumerable<FriendRequestModel>> GetFriendRequestsFrom(string userId)
        {
            var friendRequests = await _friendRequestsRepository.GetItemsAsync
                (x => x.Where(fr => fr.ConfirmedDateTime == null && fr.RequesterId == userId));

            return friendRequests.Select(Mapper.Map<FriendRequest, FriendRequestModel>);
        }

        public async Task<FriendRequestModel> GetFriendRequestById(string id)
        {
            FriendRequest dbFriendRequest = await _friendRequestsRepository.GetItemAsync(id);

            return Mapper.Map<FriendRequest, FriendRequestModel>(dbFriendRequest);
        }

        public async Task<FriendRequestModel> AddFriendRequest(string senderId, string recipientId)
        {
            FriendRequest friendRequest = new FriendRequest
            {
                RequesterId = senderId,
                ConfirmerId = recipientId,
                RequestedDateTime = DateTime.Now
            };

            return Mapper.Map<FriendRequest, FriendRequestModel>(await _friendRequestsRepository.AddItemAsync(friendRequest));
        }

        public async Task<FriendRequestModel> UpdateFriendRequest(FriendRequestModel friendRequest)
        {
            FriendRequest dbFriendRequest = Mapper.Map<FriendRequestModel, FriendRequest>(friendRequest);

            return Mapper.Map<FriendRequest, FriendRequestModel>(await _friendRequestsRepository.UpdateItemAsync(dbFriendRequest));
        }

        public async Task<FriendRequestModel> ConfirmFriendRequest(string senderId, string recipientId)
        {
            var friendRequest = await _friendRequestsRepository.GetItemAsync(
                    x => x.Where(fr => fr.ConfirmerId == senderId && recipientId == fr.RequesterId));

            friendRequest.ConfirmedDateTime = DateTime.Now;

            return await UpdateFriendRequest(Mapper.Map<FriendRequest, FriendRequestModel>(friendRequest));
        }

        public async Task<bool> DeleteFriendRequest(string userId, string friendId)
        {
            try
            {
                FriendRequest friendRequest = await _friendRequestsRepository.GetItemAsync
                (x => x.Where(fr => (fr.RequesterId == userId && fr.ConfirmerId == friendId)
                                    || (fr.RequesterId == friendId && fr.ConfirmerId == userId)));


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
