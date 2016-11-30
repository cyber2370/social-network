using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Profile
{
    public class ProfileMainViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;

        private ProfileModel _profile;

        public ProfileMainViewModel(IProfilesManager profilesManager)
        {
            _profilesManager = profilesManager;

            InitData();
        }

        public ProfileModel Profile
        {
            get { return _profile; }
            set { Set(() => Profile, ref _profile, value); }
        }

        private async void InitData()
        {
            Profile = await _profilesManager.GetCurrentProfile();
        }
    }
}
