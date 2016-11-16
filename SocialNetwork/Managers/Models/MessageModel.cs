using System;

namespace Managers.Models
{
    public class MessageModel
    {
        public int Id { get; set; }

        public string SenderId { get; set; }
        public UserModel Sender { get; set; }

        public string AddresseeId { get; set; }
        public UserModel Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
