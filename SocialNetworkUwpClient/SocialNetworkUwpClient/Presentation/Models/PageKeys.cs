﻿using System;
using SocialNetworkUwpClient.Presentation.Views;
using SocialNetworkUwpClient.Presentation.Views.Auth;
using SocialNetworkUwpClient.Presentation.Views.Profile;
using SocialNetworkUwpClient.Presentation.Views.Statistics;
using SocialNetworkUwpClient.Presentation.Views.Workplaces;
using LoginPage = SocialNetworkUwpClient.Presentation.Views.Auth.LoginPage;

namespace SocialNetworkUwpClient.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(ShellPage))]
        Shell,

        [PageType(typeof(LoginPage))]
        Login,
        [PageType(typeof(RegisterPage))]
        Register,

        [PageType(typeof(ProfileShellPage))]
        ProfileShell,
        [PageType(typeof(ProfileMainPage))]
        ProfileMain,
        [PageType(typeof(ProfileCreatingPage))]
        ProfileCreating,

        [PageType(typeof(WorkplacesShellPage))]
        WorkplacesShell,
        [PageType(typeof(WorkplacesMainPage))]
        WorkplacesMain,
        [PageType(typeof(WorkplacesEditPage))]
        WorkplacesEdit,


        [PageType(typeof(StatisticsShellPage))]
        StatisticsShell,
        [PageType(typeof(StatisticsMainPage))]
        StatisticsMain,
        [PageType(typeof(StatisticsUsersPage))]
        StatisticsUsers
    }

    public class PageTypeAttribute : Attribute
    {
        public PageTypeAttribute(Type pageType)
        {
            PageType = pageType;
        }

        public Type PageType { get; private set; }
    }
}