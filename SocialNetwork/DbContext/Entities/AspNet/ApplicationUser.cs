using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DbContext.Entities.AspNet
{
    public class ApplicationUser : IdentityUser
    {
        public UserProfile Profile { get; set; }
    }
}
