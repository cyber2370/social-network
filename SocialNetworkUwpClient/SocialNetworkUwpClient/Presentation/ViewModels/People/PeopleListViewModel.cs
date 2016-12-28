using System;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;

namespace SocialNetworkUwpClient.Presentation.ViewModels.People
{
    public class PeopleListViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        private readonly ICustomNavigationService _customNavigationService;

        private IList<ProfileModel> _people;
        
        private User _currentUser;
        private ProfileModel _selectedPerson;

        public PeopleListViewModel(
            IProfilesManager profilesManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("PeopleInternal");

            _currentUser = preferencesService.User;

            LoadData();
        }

        public IList<ProfileModel> People
        {
            get { return _people; }
            set { Set(() => People, ref _people, value); }
        }

        public ProfileModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                Set(() => SelectedPerson, ref _selectedPerson, value);

                _customNavigationService.NavigateTo(PageKeys.PeopleProfile, value.UserId);
            }
        }

        private async void LoadData()
        {
            try
            {
                IsBusy = true;
                var profiles = (await _profilesManager.GetProfiles()).ToList();

                var currentProfile = profiles.SingleOrDefault(x => x.UserId == _currentUser.Id);
                profiles.Remove(currentProfile);

                People = profiles;
                IsBusy = false;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
    }
}
