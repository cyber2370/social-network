using DbContext;
using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity.EntityFramework;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class AspNetRolesRepository : RoleStore<AspNetRole, int, AspNetUserRole>
    {
        public AspNetRolesRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
