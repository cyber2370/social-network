using System;
using System.Net;
using System.Windows.Input;
using Windows.Graphics.Printing;
using Windows.UI.Xaml.Printing;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.Helpers;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Profile
{
    public class ProfileMainViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        private readonly IPreferencesService _preferencesService;
        private readonly ICustomNavigationService _customNavigationService;

        private Data.Api.SocialNetworkApi.Social.Entities.Profile _profile;

        public ProfileMainViewModel(
            IProfilesManager profilesManager,
            IPreferencesService preferencesService)
        {
            _profilesManager = profilesManager;
            _preferencesService = preferencesService;
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("ProfileInternal");

            EditCommand = new RelayCommand(EditProfile);

            InitData();
        }
        public ICommand EditCommand { get; }
        
        public Data.Api.SocialNetworkApi.Social.Entities.Profile Profile
        {
            get { return _profile; }
            set { Set(() => Profile, ref _profile, value); }
        }

        private async void InitData()
        {
            Profile = new Data.Api.SocialNetworkApi.Social.Entities.Profile();

            try
            {
                Profile = await _profilesManager.GetCurrentProfile();
            }
            catch (HttpException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    NavigationService.NavigateTo(PageKeys.ProfileCreating);
                }
                else
                {
                    HandleError(ex);
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void EditProfile()
        {
            _customNavigationService.NavigateTo(PageKeys.ProfileCreating, Profile);
        }
    }
}
