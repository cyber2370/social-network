using System;

namespace DbContext.Entities
{
    public class FriendRequest
    {
        public int Id { get; set; }

        public int RequesterId { get; set; }
        public UserProfile Requester { get; set; }

        public int ConfirmerId { get; set; }
        public UserProfile Confirmer { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
