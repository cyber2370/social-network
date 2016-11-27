using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SocialNetworkUwpClient.Business.Managers.Interfaces;
using SocialNetworkUwpClient.Presentation.ViewModels.Common;
using ProfileModel = SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities.Profile;

namespace SocialNetworkUwpClient.Presentation.ViewModels.Profile
{
    public class ProfileCreatingViewModel : ViewModelBase
    {
        private readonly IProfilesManager _profilesManager;
        public ProfileCreatingViewModel(IProfilesManager profilesManager)
        {
            _profilesManager = profilesManager;

            CreateProfileCommand = new RelayCommand(CreateProfile);
        }

        public ICommand CreateProfileCommand { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string RelationshipStatus { get; set; }

        public string Sex { get; set; }

        public string AdditionalInformation { get; set; }

        private async void CreateProfile()
        {
            var profile = new ProfileModel
            {
                Name = Name,
                Surname = Surname, 
                BirthDate = BirthDate.DateTime,
                RelationshipStatus = RelationshipStatus,
                Sex = Sex,
                AdditionalInformation = AdditionalInformation
            };

            profile = await _profilesManager.CreateProfile(profile);
        }
    }
}
