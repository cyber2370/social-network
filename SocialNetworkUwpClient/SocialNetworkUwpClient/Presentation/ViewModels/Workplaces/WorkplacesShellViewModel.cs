﻿using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Presentation.Helpers;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Workplaces
{
    public class WorkplacesShellViewModel : ViewModelBase
    {
        private readonly ICustomNavigationService _customNavigationService;

        private Type _currentPageType;

        public WorkplacesShellViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("WorkplacesInternal");
            _customNavigationService.OnPageChanged += CustomNavigationService_OnPageChanged;

            NavTo = new RelayCommand<PageKeys>(NavigateTo);

            SetDefaultInnerPage();
        }

        private void CustomNavigationService_OnPageChanged(PageKeys pageKey, object @params)
        {
            CurrentInnerPageType = pageKey.GetPageType();
        }

        public ICommand NavTo { get; set; }

        public PageKeys Main => PageKeys.WorkplacesMain;
        public PageKeys Create => PageKeys.WorkplacesEdit;

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
            _customNavigationService.NavigateTo(PageKeys.WorkplacesMain);
        }
    }
}