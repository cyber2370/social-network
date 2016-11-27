using System;

namespace Managers.Models
{
    public class MessageModel
    {
        public int Id { get; set; }

        public string SenderId { get; set; }
        public UserProfileModel Sender { get; set; }

        public string AddresseeId { get; set; }
        public UserProfileModel Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
