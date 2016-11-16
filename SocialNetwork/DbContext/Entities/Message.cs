﻿using System;

namespace DbContext.Entities
{

    public class Message
    {
        public Message()
        {
        }

        public Message(
            string userSenderId,
            string userAddresseeId,
            string text,
            DateTime sendedDateTime)
        {
            SenderId = userSenderId;
            AddresseeId = userAddresseeId;
            Text = text;
            SendedDateTime = sendedDateTime;
        }

        public int Id { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }

        public string AddresseeId { get; set; }
        public User Addresee { get; set; }

        public string Text { get; set; }

        public DateTime SendedDateTime { get; set; }
    }
}
