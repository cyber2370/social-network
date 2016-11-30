using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Interfaces;
using SocialNetworkUwpClient.Data.Local.Interfaces;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using SocialNetworkUwpClient.Presentation.Helpers;
using SocialNetworkUwpClient.Presentation.Services.Implementations;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IProfilesManager _profilesManager;
        private readonly IPreferencesService _preferencesService;
        private readonly SessionInfoHolder _sessionInfoHolder;

        public LoginViewModel(
            IAuthenticationManager authenticationManager,
            IProfilesManager profilesManager,
            IPreferencesService preferencesService,
            SessionInfoHolder sessionInfoHolder)
        {
            _authenticationManager = authenticationManager;
            _profilesManager = profilesManager;
            _preferencesService = preferencesService;
            _sessionInfoHolder = sessionInfoHolder;

            LoginCommand = new RelayCommand(Login);
            NavigateToSignUpCommand = new RelayCommand(NavigateToSignUp);

            string defaultUsername = CustomNavigationService.CurrentPageParams?.ToString() ?? "";
            Username = defaultUsername;
        }

        public ICommand LoginCommand { get; set; }

        public ICommand NavigateToSignUpCommand { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        private void NavigateToSignUp()
        {
            NavigationService.NavigateTo(PageKeys.Register);
        }

        private async void Login()
        {
            try
            {
                if (!ValidateInputs())
                    return;

                await _authenticationManager.Authorize(Username, Password);

                await DialogService.ShowMessage("Authorization successful!", "Authorization");

                if (!await _profilesManager.CheckIfProfileExists())
                {
                    NavigationService.NavigateTo(PageKeys.ProfileCreating);
                }
                else
                {
                    //TODO: Navigate to user profile page 
                    HandleError(new Exception("Profile exists!"));
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private bool ValidateInputs()
        {
            return Username.Length > 5 && Password.Length > 5;
        }
    }
}
