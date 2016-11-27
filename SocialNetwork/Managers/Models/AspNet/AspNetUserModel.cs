using DbContext.Entities.AspNet;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Managers.Models.AspNet
{
    public class AspNetUserModel : IdentityUser<int, AspNetUserLogin, AspNetUserRole, AspNetUserClaim>
    {
        public int ProfileId { get; set; }
        public UserProfileModel Profile { get; set; }
    }
}
