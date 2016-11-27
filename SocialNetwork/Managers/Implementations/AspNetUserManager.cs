using DbContext;
using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Repositories.Implementations.AspNet;
namespace Managers.Implementations
{
    public class AspNetUserManager : UserManager<AspNetUser, int>
    {
        public AspNetUserManager(AspNetUsersRepository store)
            : base(store)
        {
        }

        public static AspNetUserManager CreateStatic(AppDbContext context)
        {
            //TODO: get new instance of AspNetUserRepository using DI
            AspNetUserManager manager = new AspNetUserManager(new AspNetUsersRepository(context));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AspNetUser, int>(manager)
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

        public static AspNetUserManager Create(IdentityFactoryOptions<AspNetUserManager> options,
            IOwinContext context)
        {
            //TODO: get new instance of AspNetUserRepository using DI
            AspNetUserManager manager = new AspNetUserManager(new AspNetUsersRepository(context.Get<AppDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<AspNetUser, int>(manager)
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
                manager.UserTokenProvider = new DataProtectorTokenProvider<AspNetUser, int>
                                            (dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
