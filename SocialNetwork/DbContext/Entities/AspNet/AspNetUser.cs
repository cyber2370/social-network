using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DbContext.Entities.AspNet
{
    public class AspNetUser : IdentityUser<int, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        public int ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
