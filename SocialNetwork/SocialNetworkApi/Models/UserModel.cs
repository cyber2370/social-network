using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbContext.Entities;
using Managers.Models;

namespace SocialNetworkApi.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public int ProfileId { get; set; }
        public UserProfile Profile { get; set; }
    }
}