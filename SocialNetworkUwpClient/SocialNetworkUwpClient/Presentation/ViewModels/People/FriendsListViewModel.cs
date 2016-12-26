using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Entities;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;

namespace SocialNetworkUwpClient.Presentation.ViewModels.People
{
    public class FriendsListViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        private readonly IFriendsManager _friendsManager;
        private readonly IPreferencesService _preferencesService;

        private IList<FriendModel> _people;

        private ProfileModel _currentUserProfile;

        public FriendsListViewModel(
            IProfilesManager profilesManager,
            IFriendsManager friendsManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _friendsManager = friendsManager;
            _preferencesService = preferencesService;
            var navService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("PeopleInternal");

            _currentUserProfile = preferencesService.Profile;

            LoadData();
        }

        public IList<FriendModel> People
        {
            get { return _people; }
            set { Set(() => People, ref _people, value); }
        }

        private async void LoadData()
        {
            var profiles = (await _friendsManager.GetFriendsOf(_currentUserProfile.UserId)).ToList();

            var currentProfile = profiles.SingleOrDefault(x => x.Id == _currentUserProfile.UserId);
            profiles?.Remove(currentProfile);

            People = profiles;
        }
    }
}
