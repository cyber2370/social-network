using System;
using System.Collections.Generic;
using System.Linq;
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
using Syncfusion.UI.Xaml.PivotGrid;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Profile
{
    public class ProfileEditViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        private readonly IPreferencesService _preferencesService;

        private DateTimeOffset _birthDateOffset;

        public ProfileEditViewModel(
            IProfilesManager profilesManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _preferencesService = preferencesService;

            var customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ProfileInternal");
            var profile = customNavigationService.CurrentPageParams as ProfileModel;
            
            Profile = profile ?? new ProfileModel();
            BirthDateOffset = profile != null ? Profile.BirthDate : DateTime.Now;

            PageText = profile == null ? "Creating Profile" : "Editing Profile";

            SaveChangesCommand = profile != null
                ? new RelayCommand(UpdateProfile) 
                : new RelayCommand(CreateProfile);

            InitData();
        }

        public ICommand SaveChangesCommand { get; set; }

        public string PageText { get; set; }

        public ProfileModel Profile { get; set; }

        public IList<RelationTypes> RelationTypeList { get; private set; }
        public IList<Sexes> SexList { get; private set; }

        public DateTimeOffset BirthDateOffset
        {
            get { return _birthDateOffset; }
            set { Set(() => BirthDateOffset, ref _birthDateOffset, value); } 
        }

        private async void CreateProfile()
        {
            Profile.BirthDate = BirthDateOffset.DateTime;

            try
            {
                _preferencesService.Profile = await _profilesManager.CreateProfile(Profile);

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
            Profile.BirthDate = BirthDateOffset.DateTime;

            try
            {
                _preferencesService.Profile = await _profilesManager.UpdateProfile(Profile);

                var csl = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ProfileInternal");
                csl.NavigateTo(PageKeys.ProfileMain);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void InitData()
        {
            SexList = Enum.GetValues(typeof(Sexes)).Cast<Sexes>().ToList();
            RelationTypeList = Enum.GetValues(typeof(RelationTypes)).Cast<RelationTypes>().ToList();
        }
    }
}
