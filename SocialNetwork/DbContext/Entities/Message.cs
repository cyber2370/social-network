using System;
using System.Collections.Generic;

namespace DbContext.Entities
{

    public class Message
    {
        public int Id { get; set; }

        public int SenderId { get; set; }
        public UserProfile Sender { get; set; }

        public int AddresseeId { get; set; }
        public UserProfile Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
