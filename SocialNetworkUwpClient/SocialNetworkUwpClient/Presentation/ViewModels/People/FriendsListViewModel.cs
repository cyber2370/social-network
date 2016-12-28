using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;

namespace SocialNetworkUwpClient.Presentation.ViewModels.People
{
    public class FriendsListViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        private readonly IFriendsManager _friendsManager;
        private readonly IPreferencesService _preferencesService;
        private readonly ICustomNavigationService _customNavigationService;

        private IList<FriendModel> _people;
        private FriendModel _selectedFriend;

        private User _currentUser;

        public FriendsListViewModel(
            IProfilesManager profilesManager,
            IFriendsManager friendsManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _friendsManager = friendsManager;
            _preferencesService = preferencesService;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("PeopleInternal");

            _currentUser = preferencesService.User;

            RemoveFriendCommand = new RelayCommand<string>(RemoveFriend);

            LoadData();
        }

        public ICommand RemoveFriendCommand { get; set; }

        public IList<FriendModel> People
        {
            get { return _people; }
            set { Set(() => People, ref _people, value); }
        }

        public FriendModel SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                Set(() => SelectedFriend, ref _selectedFriend, value);

                _customNavigationService.NavigateTo(PageKeys.PeopleProfile, value.Id);
            }
        }

        private async void LoadData()
        {
            try
            {
                IsBusy = true;
                var profiles = (await _friendsManager.GetFriendsOf(_currentUser.Id)).ToList();

                People = profiles;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private async void RemoveFriend(string friendId)
        {
            try
            {
                IsBusy = true;
                await _friendsManager.RemoveFriendsLinkingWith(friendId);

                LoadData();
                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
