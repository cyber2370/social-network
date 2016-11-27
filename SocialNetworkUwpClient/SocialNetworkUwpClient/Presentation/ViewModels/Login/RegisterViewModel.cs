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

        public RegisterViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

            RegisterCommand = new RelayCommand(Register);
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

                await _authenticationManager.Register(Username, Password);

                await DialogService.ShowMessage("Registration successful!", "Registration");

                NavigationService.NavigateTo(PageKeys.Login);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private bool ValidateInputs()
        {
            return Username.Length > 5 && Password.Length > 5 && Password == ConfirmPassword;
        }
    }
}