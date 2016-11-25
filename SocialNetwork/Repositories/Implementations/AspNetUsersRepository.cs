using Microsoft.AspNet.Identity.EntityFramework;
using DbContext;
using DbContext.Entities.AspNet;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class AspNetUsersRepository : UserStore<AspNetUser, AspNetRole, int,
        AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        public AspNetUsersRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
