using Newtonsoft.Json;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Entities
{
    public class SessionInfo
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }


        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "error", Required = Required.Default)]

        public string Error { get; set; }

        [JsonProperty(PropertyName = "error_description", Required = Required.Default)]

        public string ErrorDescription { get; set; }

        public override string ToString()
        {
            return "Bearer " + AccessToken;
        }
    }
}
