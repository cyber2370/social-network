using System;

namespace Managers.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public UserModel(
            string name,
            string surname,
            string sex,
            string avatarUri,
            DateTime birthDate,
            DateTime registrationDate,
            string email,
            string additionalInformation,
            string status,
            DateTime statusUpdated,
            string relationshipStatus,
            int homelandId)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            AvatarUri = avatarUri;
            BirthDate = birthDate;
            RegistrationDate = registrationDate;
            Email = email;
            AdditionalInformation = additionalInformation;
            Status = status;
            StatusUpdated = statusUpdated;
            RelationshipStatus = relationshipStatus;
            HomelandId = homelandId;
        }
        
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Sex { get; set; }

        public string AvatarUri { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string AdditionalInformation { get; set; }

        public string Status { get; set; }

        public DateTime StatusUpdated { get; set; }

        public string RelationshipStatus { get; set; }

        public int HomelandId { get; set; }
        public LocationModel Homeland { get; set; }
    }
}
