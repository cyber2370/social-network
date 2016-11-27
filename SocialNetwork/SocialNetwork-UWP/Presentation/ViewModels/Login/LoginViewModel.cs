using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetwork_UWP.Business.Managers.Interfaces;
using SocialNetwork_UWP.Presentation.Models;
using SocialNetwork_UWP.Presentation.ViewModels.Common;
using SocialNetwork_UWP.Presentation.Helpers;
using SocialNetwork_UWP.Presentation.Services.Implementations;

namespace SocialNetwork_UWP.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationManager _authenticationManager;

        public LoginViewModel(IAuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;

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
