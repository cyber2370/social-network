using DbContext;
using Managers.Implementations;
using Microsoft.Owin;
using Owin;
using SocialNetworkApi;

[assembly: OwinStartup(typeof(Startup))]

namespace SocialNetworkApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<AspNetUserManager>(AspNetUserManager.Create);
        }
    }
}
