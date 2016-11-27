using Microsoft.AspNet.Identity.EntityFramework;

namespace DbContext.Entities.AspNet
{
    public class AspNetUser : IdentityUser<int, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        public int ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}
