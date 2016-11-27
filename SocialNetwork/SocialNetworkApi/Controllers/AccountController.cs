using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using AutoMapper;
using DbContext.Entities.AspNet;
using Managers.Implementations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Managers;
using Managers.Models.AspNet;
using Microsoft.AspNet.Identity.Owin;
using Ninject.Infrastructure.Language;
using SocialNetworkApi.Models;
using SocialNetworkApi.Providers;
using SocialNetworkApi.Results;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";
        private AspNetUserManager _userManager;

        public AccountController(AspNetUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            _userManager = UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public AspNetUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<AspNetUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // GET api/Account/User
        [Authorize]
        [Route("User")]
        public async Task<UserModel> GetUser()
        {
            ClaimsIdentity identity = (ClaimsIdentity)User.Identity;
            string username = identity.Claims.First().Value;

            return Mapper.Map<AspNetUser, UserModel>(await UserManager.FindByNameAsync(username));
        }

        // PUT api/Account/ChangePassword
        [Route("ChangePassword")]
        [HttpPut]
        public async Task<IHttpActionResult> ChangePassword([FromBody]ChangePasswordBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserIdIntPk(), model.OldPassword,
                model.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register([FromBody]RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new AspNetUser { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                UserManager.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Helpers

        private IAuthenticationManager Authentication => Request.GetOwinContext().Authentication; 

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion
    }
}