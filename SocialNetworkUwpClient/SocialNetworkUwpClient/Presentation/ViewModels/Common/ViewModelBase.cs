using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Data.Api;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Common
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
            string message = ex.Message;

            if (ex is HttpException)
            {
                var responseEx = ex as HttpException;
                switch (responseEx.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                    {
                        await ShowMessage("Sorry, you are not authorized. Please, log in again.");
                        CustomNavigationService.NavigateTo(PageKeys.Login);
                        return;
                    }
                    case HttpStatusCode.BadRequest:
                    {
                        await ShowMessage($"Sorry, something is going wrong... \r\n" +
                                          $"Status: {responseEx.StatusCode}\r\n " +
                                          $"Http Error: {responseEx.Message}");
                        return;
                    }
                }
            }

            await ShowMessage($"Sorry, something is going wrong... \r\n" +
                              $"Error: {ex.Message}");
            return;
        }

        protected async Task ShowMessage(string message)
        {
            var dialog = new MessageDialog(message);

            await dialog.ShowAsync();
        }
    }
}