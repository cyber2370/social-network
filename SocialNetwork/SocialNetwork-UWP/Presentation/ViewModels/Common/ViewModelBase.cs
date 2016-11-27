using System;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SocialNetwork_UWP.Presentation.Services.Interfaces;

namespace SocialNetwork_UWP.Presentation.ViewModels.Common
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        public ViewModelBase()
        {
            NavigationService = ServiceLocator.Current.GetInstance<INavigationService>();
            CustomNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>();

            DialogService = new DialogService();

            GoBackCommand = new RelayCommand(NavigationService.GoBack);
        }

        protected ICustomNavigationService CustomNavigationService { get; }

        protected INavigationService NavigationService { get; }

        protected IDialogService DialogService { get; }

        public ICommand GoBackCommand { get; }

        protected async void HandleError(Exception ex)
        {
            var dialog = new MessageDialog(ex.Message);

            await dialog.ShowAsync();
        }
    }
}