using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbContext.Entities
{
    public class FriendRequest
    {
        public int Id { get; set; }

        public string RequesterUserId { get; set; }
        public UserProfile Requester { get; set; }

        public string ConfirmerUserId { get; set; }
        public UserProfile Confirmer { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
