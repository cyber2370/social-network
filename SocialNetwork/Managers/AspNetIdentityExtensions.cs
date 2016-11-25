using System;
using System.Diagnostics;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using DbContext.Entities.AspNet;
using Managers.Implementations;
using Microsoft.AspNet.Identity;

namespace Managers
{
    public static class IdentityExtensions
    {
        public static async Task<AspNetUser> FindByNameOrEmailAsync
            (this AspNetUserManager userManager, string usernameOrEmail, string password)
        {
            var username = usernameOrEmail;
            if (usernameOrEmail.Contains("@"))
            {
                var userForEmail = await userManager.FindByEmailAsync(usernameOrEmail);
                if (userForEmail != null)
                {
                    username = userForEmail.UserName;
                }
            }
            return await userManager.FindAsync(username, password);
        }

        public static AspNetUser FindByNameOrEmail
           (this AspNetUserManager userManager, string usernameOrEmail, string password)
        {
            var username = usernameOrEmail;
            if (usernameOrEmail.Contains("@"))
            {
                var userForEmail = userManager.FindByEmail(usernameOrEmail);
                if (userForEmail != null)
                {
                    username = userForEmail.UserName;
                }
            }
            return userManager.Find(username, password);
        }

        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this AspNetUser user, AspNetUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(user,
                               DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this AspNetUser user, AspNetUserManager manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public static ClaimsIdentity GenerateUserIdentity(this AspNetUser user, AspNetUserManager manager)
        {
            var userIdentity = manager.CreateIdentity(user,
                               DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        [DebuggerStepThrough]
        public static int GetUserIdIntPk(this IIdentity user)
        {
            return Convert.ToInt32(user.GetUserId());
        }
    }
}
