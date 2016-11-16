using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;
using DbContext.Entities;

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

        public async Task<FriendRequestModel> GetFriendRequestById(int id)
        {
            FriendRequest dbFriendRequest = await _friendRequestsRepository.GetItemAsync(id);

            return Mapper.Map<FriendRequest, FriendRequestModel>(dbFriendRequest);
        }

        public async Task<FriendRequestModel> AddFriendRequest(FriendRequestModel friendRequest)
        {
            FriendRequest dbFriendRequest = Mapper.Map<FriendRequestModel, FriendRequest>(friendRequest);

            return Mapper.Map<FriendRequest, FriendRequestModel>(await _friendRequestsRepository.AddItemAsync(dbFriendRequest));
        }

        public async Task<FriendRequestModel> UpdateFriendRequest(FriendRequestModel friendRequest)
        {
            FriendRequest dbFriendRequest = Mapper.Map<FriendRequestModel, FriendRequest>(friendRequest);

            return Mapper.Map<FriendRequest, FriendRequestModel>(await _friendRequestsRepository.UpdateItemAsync(dbFriendRequest));
        }

        public async Task<FriendRequestModel> ConfirmFriendRequest(FriendRequestModel friendRequest)
        {
            friendRequest.IsConfirmed = true;

            return await UpdateFriendRequest(friendRequest);
        }

        public async Task<bool> DeleteFriendRequest(int id)
        {
            try
            {
                await _friendRequestsRepository.RemoveItemAsync(id);
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
