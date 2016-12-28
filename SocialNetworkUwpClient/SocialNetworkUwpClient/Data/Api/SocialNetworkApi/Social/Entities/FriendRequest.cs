using System;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities
{
    public class FriendRequest
    {
        public int Id { get; set; }

        public string RequesterUserId { get; set; }
        public Profile Requester { get; set; }

        public string ConfirmerUserId { get; set; }
        public Profile Confirmer { get; set; }

        public DateTime RequestDateTime { get; set; }

        public DateTime? ConfirmedDateTime { get; set; }
    }
}
