using System;

namespace Managers.Models.Friends
{
    public class FriendRequestModel
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public UserModel Sender { get; set; }

        public int AddresseeId { get; set; }
        public UserModel Addressee { get; set; }

        public DateTime RequestDateTime { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
