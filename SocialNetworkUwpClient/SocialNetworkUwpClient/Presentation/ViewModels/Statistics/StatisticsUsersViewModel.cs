using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Statistics
{
    public class StatisticsUsersViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;

        public StatisticsUsersViewModel(IProfilesManager profilesManager)
        {
            _profilesManager = profilesManager;
        }

        private async void AboutSexes()
        {
            var profiles = await _profilesManager.GetProfiles();
        }
    }
}