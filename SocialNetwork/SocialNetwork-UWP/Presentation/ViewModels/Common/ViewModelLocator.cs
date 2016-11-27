using System;
using Microsoft.Practices.ServiceLocation;
using SocialNetwork_UWP.Presentation.ViewModels.Login;

namespace SocialNetwork_UWP.Presentation.ViewModels.Common
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