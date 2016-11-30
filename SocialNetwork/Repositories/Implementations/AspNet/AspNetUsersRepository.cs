using DbContext;
using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repositories.Implementations.AspNet
{
    public class AspNetUsersRepository : UserStore<ApplicationUser>
    {
        public AspNetUsersRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
