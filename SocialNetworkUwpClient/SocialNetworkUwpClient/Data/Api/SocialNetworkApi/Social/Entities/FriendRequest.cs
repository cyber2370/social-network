using System;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities
{
    public class FriendRequest
    {
        public string Id { get; set; }

        public string SenderId { get; set; }
        public Profile Sender { get; set; }

        public string AddresseeId { get; set; }
        public Profile Addressee { get; set; }

        public DateTime RequestDateTime { get; set; }

        public bool IsConfirmed { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
