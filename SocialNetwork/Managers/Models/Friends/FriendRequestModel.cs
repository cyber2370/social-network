using System;
using DbContext.Entities;

namespace Managers.Models.Friends
{
    public class FriendRequestModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public UserProfile Sender { get; set; }

        public int AddresseeId { get; set; }
        public UserProfile Addressee { get; set; }

        public DateTime RequestDateTime { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
