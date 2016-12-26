using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DbContext.Entities.AspNet;

namespace DbContext.Entities
{
    public class UserProfile
    {
        public UserProfile()
        {

        }

        public UserProfile(UserProfile profile)
        {
            UserId = profile.UserId;
            Email = profile.Email;
            Name = profile.Name;
            Surname = profile.Surname;
            Sex = profile.Sex;
            HomeCountry = profile.HomeCountry;
            AvatarUri = profile.AvatarUri;
            BirthDate = profile.BirthDate;
            RegistrationDate = profile.RegistrationDate;
            AdditionalInformation = profile.AdditionalInformation;
            Status = profile.Status;
            StatusUpdated = profile.StatusUpdated;
            RelationshipStatus = profile.RelationshipStatus;

            IncomingFriendRequests = profile.IncomingFriendRequests;
            OutgoingFriendRequests = profile.OutgoingFriendRequests;
        }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Genders Sex { get; set; }

        public string HomeCountry { get; set; }

        public string AvatarUri { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string AdditionalInformation { get; set; }

        public string Status { get; set; }

        public DateTime StatusUpdated { get; set; }

        public RelationshipTypes RelationshipStatus { get; set; }


        public virtual ApplicationUser User { get; set; }

        public IList<FriendRequest> IncomingFriendRequests { get; set; }
        public IList<FriendRequest> OutgoingFriendRequests { get; set; }
    }
}
