using System;
using GalaSoft.MvvmLight.Views;
using SocialNetwork_UWP.Presentation.Models;
using SocialNetwork_UWP.Presentation.Services.Implementations;

namespace SocialNetwork_UWP.Presentation.Helpers
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