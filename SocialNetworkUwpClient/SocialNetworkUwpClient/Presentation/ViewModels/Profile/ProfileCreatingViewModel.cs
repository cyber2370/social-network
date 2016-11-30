using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.Helpers;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Profile
{
    public class ProfileCreatingViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        private readonly IPreferencesService _preferencesService;
        
        private readonly ProfileModel _editingProfile;

        public ProfileCreatingViewModel(
            IProfilesManager profilesManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _preferencesService = preferencesService;

            var customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ProfileInternal");
            var profile = customNavigationService.CurrentPageParams as ProfileModel;
            
            _editingProfile = profile;

            SaveChangesCommand = profile != null
                ? new RelayCommand(UpdateProfile) 
                : new RelayCommand(CreateProfile);
            InitInputs();
        }

        public ICommand SaveChangesCommand { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string RelationshipStatus { get; set; }

        public string Sex { get; set; }

        public string AdditionalInformation { get; set; }

        private async void CreateProfile()
        {
            var profile = GetProfileFromPage();

            try
            {
                _preferencesService.Profile = await _profilesManager.CreateProfile(profile);

                NavigationService.NavigateTo(
                    _preferencesService.Profile != null ? PageKeys.Shell : PageKeys.Login);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private async void UpdateProfile()
        {
            var profile = GetProfileFromPage();

            _editingProfile.Name = profile.Name;
            _editingProfile.Surname = profile.Surname;
            _editingProfile.BirthDate = profile.BirthDate;
            _editingProfile.RelationshipStatus = profile.RelationshipStatus;
            _editingProfile.Sex = profile.Sex;
            _editingProfile.AdditionalInformation = profile.AdditionalInformation;

            try
            {
                _preferencesService.Profile = await _profilesManager.CreateProfile(profile);

                NavigationService.NavigateTo(
                    _preferencesService.Profile != null ? PageKeys.Shell : PageKeys.Login);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void InitInputs()
        {
            Name = _editingProfile?.Name;
            Surname = _editingProfile?.Surname;
            BirthDate = _editingProfile?.BirthDate ?? DateTime.Now;
            RelationshipStatus = _editingProfile?.RelationshipStatus;
            Sex = _editingProfile?.Sex;
            AdditionalInformation = _editingProfile?.AdditionalInformation;
        }

        private ProfileModel GetProfileFromPage()
        {
            return new ProfileModel
            {
                Name = Name,
                Surname = Surname,
                BirthDate = BirthDate.DateTime,
                RelationshipStatus = RelationshipStatus,
                Sex = Sex,
                AdditionalInformation = AdditionalInformation
            };
        }
    }
}
