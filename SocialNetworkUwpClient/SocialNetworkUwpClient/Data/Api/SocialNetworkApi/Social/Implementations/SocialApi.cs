using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Implementations
{
    public class SocialApi : ISocialApi
    {
        private readonly string _apiBaseAddress;

        public SocialApi()
        {
            var apiRouting = new ApiRouting();
            _apiBaseAddress = apiRouting.SocialNetworkApiUrl;
        }

        public Task<User> GetUser()
        {
            return GetRestApi().GetUser();
        }

        public Task<IEnumerable<Profile>> GetProfiles()
        {
            return GetRestApi().GetProfiles();
        }

        public Task<Profile> GetProfile()
        {
            return GetRestApi().GetProfile();
        }

        public Task<Profile> GetProfileById(string id)
        {
            return GetRestApi().GetProfileById(id);
        }

        public Task<Profile> GetProfileOf(string userId)
        {
            return GetRestApi().GetProfileByUserId(userId);
        }

        public Task<bool> CheckIfProfileExists()
        {
            return GetRestApi().CheckIfProfileExists();
        }

        public Task<Profile> CreateProfile(Profile profile)
        {
            return GetRestApi().CreateProfile(profile);
        }

        public Task<Profile> UpdateProfile(Profile profile)
        {
            return GetRestApi().UpdateProfile(profile);
        }


        // FRIENDS
        public Task<IEnumerable<Profile>> GetFriendsOf(string userId)
        {
            return GetRestApi().GetFriendsOf(userId);
        }

        public Task<IEnumerable<FriendRequest>> GetOutgoingFriendRequests()
        {
            return GetRestApi().GetFriendRequestsOfCurrentUser();
        }

        public Task<IEnumerable<FriendRequest>> GetIncomingFriendRequests()
        {
            return GetRestApi().GetFriendRequestsToCurrentUser();
        }

        public Task<bool> ConfirmFriendRequest(string friendId)
        {
            return GetRestApi().ConfirmFriendRequest(friendId);
        }

        public Task<FriendRequest> SendFriendRequestTo(string userId)
        {
            return GetRestApi().SendFriendRequestTo(userId);
        }

        public Task<bool> RemoveFriends(string userId)
        {
            return GetRestApi().RemoveFriends(userId);
        }


        // WORKPLACES 
        public Task<IEnumerable<Workplace>> GetWorkplaces()
        {
            return GetRestApi().GetWorkplaces();
        }

        public Task<Workplace> GetWorkplaceById(int id)
        {
            return GetRestApi().GetWorkplaceById(id);
        }

        public Task<Workplace> CreateWorkplace(Workplace workplace)
        {
            return GetRestApi().CreateWorkplace(workplace);
        }

        public Task<Workplace> UpdateWorkplace(Workplace workplace)
        {
            return GetRestApi().UpdateWorkplace(workplace);
        }

        public Task DeleteWorkplace(int id)
        {
            return GetRestApi().DeleteWorkplace(id);
        }

        public Task<UsersReport> GetUsersReport()
        {
            return GetRestApi().GetUsersReport();
        }


        private RestApi GetRestApi()
        {
            return new RestApi(new Uri(_apiBaseAddress));
        }
    }
}