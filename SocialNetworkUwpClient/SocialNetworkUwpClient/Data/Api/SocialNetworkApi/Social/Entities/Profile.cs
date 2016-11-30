using System;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities
{
    public class Profile
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Sex { get; set; }

        public Uri AvatarUri { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string AdditionalInformation { get; set; }

        public string Status { get; set; }

        public DateTime StatusUpdated { get; set; }

        public string RelationshipStatus { get; set; }
        public User User { get; set; }
    }
}
