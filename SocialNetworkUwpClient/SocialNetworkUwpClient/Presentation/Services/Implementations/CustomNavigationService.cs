using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;

namespace SocialNetworkUwpClient.Presentation.Services.Implementations
{
    class CustomNavigationService : ICustomNavigationService
    {
        private NavigationPageHelper _pagePair;

        private class NavigationPageHelper
        {
            public NavigationPageHelper(PageKeys pageKey, object @params = null)
            {
                PageKey = pageKey;
                Params = @params;
            }

            public PageKeys PageKey { get; }

            public object Params { get; }
        }

        public CustomNavigationService()
        {
            _pagePair = new NavigationPageHelper(PageKeys.Login);
        }

        public event PageChangedDelegate OnPageChanged;

        public void NavigateTo(PageKeys pageKey, object @params = null)
        {
            _pagePair = new NavigationPageHelper(pageKey, @params);

            OnPageChanged?.Invoke(pageKey, @params);
        }

        public PageKeys CurrentPageKey => _pagePair.PageKey;
        public object CurrentPageParams => _pagePair?.Params;
    }
}