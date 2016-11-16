using System;

namespace DbContext.Entities
{

    public class Message
    {
        public Message()
        {
        }

        public Message(
            int userSenderId,
            int userAddresseeId,
            string text,
            DateTime sendedDateTime)
        {
            UserSenderId = userSenderId;
            UserAddresseeId = userAddresseeId;
            Text = text;
            SendedDateTime = sendedDateTime;
        }

        public int Id { get; set; }

        public int UserSenderId { get; set; }
        public User Sender { get; set; }

        public int UserAddresseeId { get; set; }
        public User Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
