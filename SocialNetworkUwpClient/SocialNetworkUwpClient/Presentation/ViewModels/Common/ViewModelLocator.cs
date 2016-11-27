using System;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Presentation.ViewModels.Login;
using SocialNetworkUwpClient.Presentation.ViewModels.Profile;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Common
{
    public class ViewModelLocator
    {
        public LoginViewModel Login => GetViewModel<LoginViewModel>();
        public RegisterViewModel Register => GetViewModel<RegisterViewModel>();
        public ProfileCreatingViewModel ProfileCreating => GetViewModel<ProfileCreatingViewModel>();

        


        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>(Guid.NewGuid().ToString());
        }
    }
}