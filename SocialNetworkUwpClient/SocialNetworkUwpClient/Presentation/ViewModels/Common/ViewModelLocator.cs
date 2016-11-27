using System;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Presentation.ViewModels.Login;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Common
{
    public class ViewModelLocator
    {
        public LoginViewModel Login => GetViewModel<LoginViewModel>();
        public RegisterViewModel Register => GetViewModel<RegisterViewModel>();


        private T GetViewModel<T>()
        {
            return ServiceLocator.Current.GetInstance<T>(Guid.NewGuid().ToString());
        }
    }
}