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
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IProfilesManager _profilesManager;
        private readonly IPreferencesService _preferencesService;

        public LoginViewModel(
            IAuthenticationManager authenticationManager,
            IProfilesManager profilesManager,
            IPreferencesService preferencesService)
        {
            _authenticationManager = authenticationManager;
            _profilesManager = profilesManager;
            _preferencesService = preferencesService;

            preferencesService.Clear();

            LoginCommand = new RelayCommand(Login);
            NavigateToSignUpCommand = new RelayCommand(NavigateToSignUp);

            string defaultUsername = CustomNavigationService.CurrentPageParams?.ToString() ?? "";
            Username = defaultUsername;
            IsBusy = false;
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
                if (!await ValidateInputs())
                    return;

                IsBusy = true;

                await _authenticationManager.Authorize(Username, Password);

                IsBusy = false;

                await DialogService.ShowMessage("Authorization successful!", "Authorization");

                bool isProfileCreated = await _profilesManager.CheckIfProfileExists();
                NavigationService.NavigateTo(isProfileCreated ? PageKeys.Shell : PageKeys.ProfileCreating);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                HandleError(ex);
            }
        }

        private async Task<bool> ValidateInputs()
        {
            IList<string> errors = new List<string>();

            if(Username.Length < 6)
            {
                errors.Add("Username must contain more than 5 symbols!");
            }

            if(Password.Length < 6)
            {
                errors.Add("Password must contain more than 5 symbols!");
            }

            string errorString = "";
            foreach(string err in errors)
            {
                errorString += "\r\n" + err;
            }
            if (errors.Any())
            {
                await ShowMessage(errorString);
                return false;
            }

            return true;
        }
    }
}
