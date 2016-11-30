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
        public static async Task<ApplicationUser> FindByNameOrEmailAsync
            (this ApplicationUserManager userManager, string usernameOrEmail, string password)
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

        public static ApplicationUser FindByNameOrEmail
           (this ApplicationUserManager userManager, string usernameOrEmail, string password)
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

        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this ApplicationUser user, ApplicationUserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(user,
                               DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(this ApplicationUser user, ApplicationUserManager manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public static ClaimsIdentity GenerateUserIdentity(this ApplicationUser user, ApplicationUserManager manager)
        {
            var userIdentity = manager.CreateIdentity(user,
                               DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
        
        public static int GetUserIdIntPk(this IIdentity user)
        {
            var userId = user.GetUserId();

            return Convert.ToInt32(userId);
        }
    }
}
