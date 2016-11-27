namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Social.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
