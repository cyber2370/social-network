using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Presentation.Models;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Statistics
{
    public class StatisticsMainViewModel : ViewModelBase
    {

        private readonly ICustomNavigationService _customNavigationService;

        public StatisticsMainViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>("StatisticsInternal");

            NavTo = new RelayCommand<PageKeys>(NavigateTo);
        }

        public ICommand NavTo { get; set; }

        public PageKeys Users => PageKeys.StatisticsUsers;

        private void NavigateTo(PageKeys pageKey)
        {
            _customNavigationService.NavigateTo(pageKey);
        }

    }
}
