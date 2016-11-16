using System;

namespace DbContext.Entities
{

    public class Message
    {
        public Message()
        {
        }

        public Message(
            int senderId,
            int addresseeId,
            string text,
            DateTime sendedDateTime)
        {
            SenderId = senderId;
            AddresseeId = addresseeId;
            Text = text;
            SendedDateTime = sendedDateTime;
        }

        public int Id { get; set; }

        public int SenderId { get; set; }
        public User Sender { get; set; }

        public int AddresseeId { get; set; }
        public User Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
