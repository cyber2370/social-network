using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace DbContext.Entities.AspNet
{
    public class AspNetRole : IdentityRole<int, AspNetUserRole>
    {
    }
}
