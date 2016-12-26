using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Presentation.Helpers;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using System;
using System.Windows.Input;

namespace SocialNetworkUwpClient.Presentation.ViewModels.People
{
    public class PeopleShellViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;

        private Type _currentPageType;

        public PeopleShellViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("PeopleInternal");
            _customNavigationService.OnPageChanged += CustomNavigationService_OnPageChanged;

            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        private void CustomNavigationService_OnPageChanged(PageKeys pageKey, object @params)
        {
            CurrentInnerPageType = pageKey.GetPageType();
        }

        public ICommand NavTo { get; set; }

        public PageKeys People => PageKeys.PeopleList;
        public PageKeys Friends => PageKeys.PeopleList;

        public Type CurrentInnerPageType
        {
            get { return _currentPageType; }
            set { Set(() => CurrentInnerPageType, ref _currentPageType, value); }
        }

        private void NavigateTo(PageKeys pageKey)
        {
            _customNavigationService.NavigateTo(pageKey);
        }

        private void SetDefaultInnerPage()
        {
            _customNavigationService.NavigateTo(PageKeys.PeopleList);
        }
    }
}
