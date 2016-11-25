using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DbContext.Entities.AspNet;

namespace DbContext.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }

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
        public Location Homeland { get; set; }

        public AspNetUser AspNetUser { get; set; }
        public int AspNetUserId { get; set; }

        public IList<FriendRequest> IncomingFriendRequests { get; set; }
        public IList<FriendRequest> OutgoingFriendRequests { get; set; }
    }
}
