using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetwork_UWP.Presentation.ViewModels.Common;

namespace SocialNetwork_UWP.Presentation.ViewModels.Login
{
    public class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel()
        {
             RegisterCommand = new RelayCommand(Register);
        }

        public ICommand RegisterCommand { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        private void Register()
        {
            var registrationModel = new RegisterViewModel
            {
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };

            // send model to server

            // if success then navigate to profile creating
        }

    }
}
