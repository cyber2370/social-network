using System;
using SocialNetworkUwpClient.Presentation.Views.Auth;
using LoginPage = SocialNetworkUwpClient.Presentation.Views.Auth.LoginPage;

namespace SocialNetworkUwpClient.Presentation.Models
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