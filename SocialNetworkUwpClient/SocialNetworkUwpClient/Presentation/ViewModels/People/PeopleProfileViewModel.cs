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
        private readonly IProfilesManager _profilesManager;
        private readonly IFriendsManager _friendsManager;
        private readonly ICustomNavigationService _customNavigationService;
        private readonly IPreferencesService _preferencesService;

        private ProfileModel _personProfile;
        private readonly string _personProfileId;
        private ProfileModel _profile;
        private bool _isFriend;

        private string _friendButtonText;

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
            FriendButtonText = "Add Friend";

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

        public ICommand FriendButtonCommand { get; set; }

        private async void LoadProfile()
        {
            try
            {
                PersonProfile = await _profilesManager.GetProfileById(_personProfileId);

                _isFriend = await _friendsManager.CheckIfFriendsWith(_personProfileId);

                FriendButtonText = _isFriend ? "Remove from friends" : "Send Request For Friends";
                FriendButtonCommand = _isFriend ? new RelayCommand(RemoveFriend)  : new RelayCommand(AddFriend);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private async void RemoveFriend()
        {
            await _friendsManager.RemoveFriendsLinkingWith(_personProfileId);

            await ShowMessage("Successfully deleted!");

            _customNavigationService.NavigateTo(PageKeys.FriendsList);
        }

        private async void AddFriend()
        {
            await _friendsManager.SendFriendRequestTo(_personProfileId);

            await ShowMessage("Successfully sended!");

            _customNavigationService.NavigateTo(PageKeys.FriendsList);
        }
    }
}
