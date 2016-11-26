using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetwork_UWP.Presentation.Models;
using SocialNetwork_UWP.Presentation.ViewModels.Common;
using SocialNetwork_UWP.Presentation.Helpers;

namespace SocialNetwork_UWP.Presentation.ViewModels.Login
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            NavigateToSignUpCommand = new RelayCommand(NavigateToSignUp);
        }

        public ICommand LoginCommand { get; set; }

        public ICommand NavigateToSignUpCommand { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        private void NavigateToSignUp()
        {
            NavigationService.NavigateTo(PageKeys.Register);
        }

        private void Login()
        {

        }
    }
}
