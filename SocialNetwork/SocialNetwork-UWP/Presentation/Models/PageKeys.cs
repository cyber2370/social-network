using System;
using SocialNetwork_UWP.Presentation.Views.Auth;
using LoginPage = SocialNetwork_UWP.Presentation.Views.Auth.LoginPage;

namespace SocialNetwork_UWP.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(LoginPage))]
        Login,
        [PageType(typeof(RegisterPage))]
        Register,
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