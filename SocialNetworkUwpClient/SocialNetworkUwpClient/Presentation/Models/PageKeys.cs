using System;
using SocialNetworkUwpClient.Presentation.Views.Auth;
using SocialNetworkUwpClient.Presentation.Views.Profile;
using LoginPage = SocialNetworkUwpClient.Presentation.Views.Auth.LoginPage;

namespace SocialNetworkUwpClient.Presentation.Models
{
    public enum PageKeys
    {
        [PageType(typeof(LoginPage))]
        Login,
        [PageType(typeof(RegisterPage))]
        Register,
        [PageType(typeof(ProfileCreatingPage))]
        ProfileCreating
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