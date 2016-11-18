using System;

namespace DbContext.Entities
{

    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int AddresseeId { get; set; }
        public User Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
