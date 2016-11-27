using System;
using System.Threading.Tasks;
using SocialNetworkUwpClient.Data.Api.Rest;
using SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Entities;

namespace SocialNetworkUwpClient.Data.Api.SocialNetworkApi.Auth.Implementations
{
    class RestApi : RestApiBase
    {
        public RestApi(Uri baseAddress) : base(baseAddress)
        {

        }

        public Task<SessionInfo> Login(string grantType, string username, string password)
        {
            return Url("token")
                .FormUrlEncoded()
                .Param("grant_type", grantType)
                .Param("username", username)
                .Param("password", password)
                .PostAsync<SessionInfo>();
        }

        public Task Register(string email, string password, string confirmPassword)
        {
            return Url("account/register")
                .FormUrlEncoded()
                .Param("Email", email)
                .Param("Password", password)
                .Param("ConfirmPassword", confirmPassword)
                .PostAsync();
        }

        public Task ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            return Url("account/changePassword")
                .FormUrlEncoded()
                .Param("OldPassword", oldPassword)
                .Param("NewPassword", newPassword)
                .Param("ConfirmPassword", confirmPassword)
                .PutAsync();
        }
    }
}
