using DbContext;
using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Repositories.Implementations.AspNet;
namespace Managers.Implementations
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(AspNetUsersRepository store)
            : base(store)
        {
        }

        public static ApplicationUserManager CreateStatic(AppDbContext context)
        {
            //TODO: get new instance of AspNetUserRepository using DI
            ApplicationUserManager manager = new ApplicationUserManager(new AspNetUsersRepository(context));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
            };

            return manager;
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            //TODO: get new instance of AspNetUserRepository using DI
            ApplicationUserManager manager = new ApplicationUserManager(new AspNetUsersRepository(context.Get<AppDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>
                                            (dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
