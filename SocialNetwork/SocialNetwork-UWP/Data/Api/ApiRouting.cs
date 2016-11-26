namespace SocialNetwork_UWP.Data.Api
{
    public class ApiRouting
    {
        private const string SocialNetworkServiceAddress = "http://localhost:55555";
        
        public string SocialNetworkApiUrl => SocialNetworkServiceAddress + "/";
    }
}
