using System;
using System.Collections.Generic;
using DbContext.Entities;
using Managers.Models.AspNet;

namespace Managers.Models
{
    public class UserProfileModel
    {
        public int Id { get; set; }
        
        public string Email { get; set; }

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

        public int HomelandId { get; set; }
        public LocationModel Homeland { get; set; }

        public int UserId { get; set; }
        public AspNetUserModel User { get; set; }

        public IList<FriendRequest> IncomingFriendRequests { get; set; }
        public IList<FriendRequest> OutgoingFriendRequests { get; set; }
    }
}
