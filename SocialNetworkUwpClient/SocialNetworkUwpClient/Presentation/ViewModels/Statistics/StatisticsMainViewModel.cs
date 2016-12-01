using System.Windows.Input;
using Microsoft.Practices.ServiceLocation;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Presentation.Services.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Statistics
{
    public class StatisticsMainViewModel : ViewModelBase
    {

        private readonly ICustomNavigationService _customNavigationService;

        public StatisticsMainViewModel()
        {
            _customNavigationService = ServiceLocator.Current.GetInstance<ICustomNavigationService>();
        }

        public ICommand NavToCommand { get; set; }

        private void NavTo()
        {
            
        }
    }
}
