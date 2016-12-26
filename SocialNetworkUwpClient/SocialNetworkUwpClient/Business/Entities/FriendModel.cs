using System;

namespace SocialNetworkUwpClient.Business.Entities
{
    public class FriendModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Uri AvatarUri { get; set; }

    }
}
