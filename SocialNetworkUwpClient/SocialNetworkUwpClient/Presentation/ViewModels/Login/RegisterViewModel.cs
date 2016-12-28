using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using SocialNetworkUwpClient.Presentation.Helpers;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Login
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IProfilesManager _profilesManager;

        public RegisterViewModel(
            IAuthenticationManager authenticationManager,
            IProfilesManager profilesManager)
        {
            _authenticationManager = authenticationManager;
            _profilesManager = profilesManager;

            RegisterCommand = new RelayCommand(Register);
            IsBusy = false;
        }

        public ICommand RegisterCommand { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        private async void Register()
        {
            try
            {
                if (!ValidateInputs())
                    return;
                IsBusy = true;
                await _authenticationManager.Register(Username, Password);
                IsBusy = false;

                await DialogService.ShowMessage("Registration successful!", "Registration");

                IsBusy = true;
                await _authenticationManager.Authorize(Username, Password);
                bool isProfileCreated = await _profilesManager.CheckIfProfileExists();
                IsBusy = false;

                NavigationService.NavigateTo(isProfileCreated ? PageKeys.Shell : PageKeys.ProfileCreating);
            }
            catch (Exception ex)
            {
                IsBusy = false;
                HandleError(ex);
            }
        }

        private bool ValidateInputs()
        {
            return Username.Length > 5 && Password.Length > 5 && Password == ConfirmPassword;
        }
    }
}