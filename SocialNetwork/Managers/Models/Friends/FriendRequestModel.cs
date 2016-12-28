using System;
using DbContext.Entities;

namespace Managers.Models.Friends
{
    public class FriendRequestModel
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
