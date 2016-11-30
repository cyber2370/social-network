using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using DbContext.Entities.AspNet;
using Managers.Implementations;
using Microsoft.AspNet.Identity.Owin;
using SocialNetworkApi.Models;

namespace SocialNetworkApi.Controllers
{
    public class ApiControllerBase : ApiController
    {

        protected async Task<ApplicationUser> GetCurrentUser(ApplicationUserManager userManager)
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            string username = identity.Claims.First().Value;

            return await userManager.FindByNameAsync(username);
        }
    }
}