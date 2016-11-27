namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Entities
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        
        public string NewPassword { get; set; }
        
        public string ConfirmPassword { get; set; }
    }
}
