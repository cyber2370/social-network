using System;

namespace DbContext.Entities
{
    public class FriendRequest
    {
        public string Id { get; set; }

        public string RequesterId { get; set; }
        public UserProfile Requester { get; set; }

        public string ConfirmerId { get; set; }
        public UserProfile Confirmer { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
