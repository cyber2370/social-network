using System;

namespace Managers.Models
{

    public class MessageModel
    {
        public MessageModel()
        {
        }

        public MessageModel(
            UserModel sender,
            UserModel addressee,
            string text,
            DateTime sendedDateTime)
        {
            Sender = sender;
            Addresee = addressee;
            Text = text;
            SendedDateTime = sendedDateTime;
        }

        public int Id { get; set; }

        public string SenderId { get; set; }
        public UserModel Sender { get; set; }

        public string AddresseeId { get; set; }
        public UserModel Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
