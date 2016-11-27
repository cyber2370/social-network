using DbContext;
using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repositories.Implementations.AspNet
{
    public class AspNetRolesRepository : RoleStore<AspNetRole, int, AspNetUserRole>
    {
        public AspNetRolesRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
