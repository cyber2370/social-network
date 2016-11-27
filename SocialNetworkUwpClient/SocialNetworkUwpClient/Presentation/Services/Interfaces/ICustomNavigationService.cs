using SocialNetworkUwpClient.Presentation.Models;

namespace SocialNetworkUwpClient.Presentation.Services.Interfaces
{
    public delegate void PageChangedDelegate(PageKeys pageKey, object @params = null);

    public interface ICustomNavigationService
    {
        event PageChangedDelegate OnPageChanged;

        void NavigateTo(PageKeys pageKey, object @params = null);

        PageKeys CurrentPageKey { get; }
        object CurrentPageParams { get; }
    }
}