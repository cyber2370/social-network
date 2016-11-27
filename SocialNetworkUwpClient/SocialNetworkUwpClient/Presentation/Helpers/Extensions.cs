﻿using System;
using GalaSoft.MvvmLight.Views;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Implementations;

namespace SocialNetworkUwpClient.Presentation.Helpers
{
    public static class Extensions
    {
        public static void NavigateTo(
            this INavigationService navigationService,
            PageKeys pageKey,
            params object[] parameters)
        {
            navigationService.NavigateTo(pageKey.ToString(), parameters);
        }

        public static Type GetPageType(this PageKeys pageKey)
        {
            return NavigationServiceHepler.GetPageTypeByKey(pageKey);
        }
    }
}