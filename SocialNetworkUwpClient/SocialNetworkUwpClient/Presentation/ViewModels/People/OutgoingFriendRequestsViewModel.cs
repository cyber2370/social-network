using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.People
{
    public class OutgoingFriendRequestsViewModel : ViewModelBase
    {
        private readonly IFriendsManager _friendsManager;

        private IList<FriendRequest> _friendRequestList;

        public OutgoingFriendRequestsViewModel(IFriendsManager friendsManager)
        {
            _friendsManager = friendsManager;

            RemoveFriendRequestCommand = new RelayCommand<string>(RemoveFriendRequest);

            LoadFriends();
        }

        public ICommand RemoveFriendRequestCommand { get; set; }

        public IList<FriendRequest> FriendRequestsList
        {
            get { return _friendRequestList; }
            set { Set(() => FriendRequestsList, ref _friendRequestList, value); }
        }

        private async void LoadFriends()
        {
            IsBusy = true;
            FriendRequestsList = (await _friendsManager.GetOutgoingFriendRequests()).ToList();
            IsBusy = false;
        }

        private async void RemoveFriendRequest(string friendId)
        {
            try
            {
                IsBusy = true;
                await _friendsManager.RemoveFriendsLinkingWith(friendId);

                LoadFriends();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
