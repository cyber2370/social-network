using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;

namespace SocialNetworkUwpClient.Presentation.ViewModels.People
{
    public class PeopleProfileViewModel : ViewModelBase
    {
        private enum FriendRequestStatus
        {
            Confirmed, 
            NotConfirmed,
            NotSended
        }

        private readonly IProfilesManager _profilesManager;
        private readonly IFriendsManager _friendsManager;
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IPreferencesService _preferencesService;

        private ProfileModel _personProfile;
        private readonly string _personProfileId;
        private ProfileModel _profile;
        private FriendRequestStatus _friendRequestStatus;

        private string _friendButtonText;
        private ICommand _friendButtonCommand;

        public PeopleProfileViewModel(
            IProfilesManager profilesManager,
            IFriendsManager friendsManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _friendsManager = friendsManager;
            _preferencesService = preferencesService;

            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("PeopleInternal");
            _personProfileId = (string) _customNavigationService.CurrentPageParams;

            _profile = preferencesService.Profile;

            LoadProfile();
        }

        public string FriendButtonText
        {
            get { return _friendButtonText; }
            set { Set(() => FriendButtonText, ref _friendButtonText, value); }
        }

        public ProfileModel PersonProfile
        {
            get { return _personProfile; }
            set { Set(() => PersonProfile, ref _personProfile, value); }
        }

        public ICommand FriendButtonCommand
        {
            get { return _friendButtonCommand; }
            set { Set(() => FriendButtonCommand, ref _friendButtonCommand, value); }
            
        }

        private async void LoadProfile()
        {
            try
            {
                IsBusy = true;
                PersonProfile = await _profilesManager.GetProfileById(_personProfileId);

                var friendRequest = await _friendsManager.CheckIfFriendsWith(_personProfileId);
                if (friendRequest == null)
                {
                    _friendRequestStatus = FriendRequestStatus.NotSended;
                }
                else if (friendRequest.ConfirmedDateTime == null)
                {
                    _friendRequestStatus = FriendRequestStatus.NotConfirmed;
                }
                else
                {
                    _friendRequestStatus = FriendRequestStatus.Confirmed;
                }

                switch (_friendRequestStatus)
                {
                    case FriendRequestStatus.Confirmed:
                    {
                        FriendButtonText = "Remove from friends";
                        FriendButtonCommand = new RelayCommand(RemoveFriend);
                        break;
                    }
                    case FriendRequestStatus.NotConfirmed:
                    {
                        FriendButtonText = "Cancel Friend Request";
                        FriendButtonCommand = new RelayCommand(RemoveFriend);
                        break;
                    }
                    case FriendRequestStatus.NotSended:
                    {
                        FriendButtonText = "Send Request For Friends";
                        FriendButtonCommand = new RelayCommand(AddFriend);
                        break;
                    }
                }

                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private async void RemoveFriend()
        {
            try
            {
                IsBusy = true;
                await _friendsManager.RemoveFriendsLinkingWith(_personProfileId);
                IsBusy = false;

                await ShowMessage("Successfully deleted!");

                _customNavigationService.NavigateTo(PageKeys.FriendsList);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private async void AddFriend()
        {
            try
            {
                IsBusy = true;
                await _friendsManager.SendFriendRequestTo(_personProfileId);
                IsBusy = false;

                await ShowMessage("Successfully sended!");

                _customNavigationService.NavigateTo(PageKeys.FriendsList);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
