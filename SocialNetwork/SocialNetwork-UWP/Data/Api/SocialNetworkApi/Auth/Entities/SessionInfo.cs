using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SocialNetwork_UWP.Data.Api.SocialNetworkApi.Auth.Entities
{
    public class SessionInfo
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime LoggedDateTime { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime ExpiresDateTime { get; set; }
    }
}
