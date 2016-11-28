using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using DbContext.Entities.AspNet;
using Managers.Implementations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Managers;
using SocialNetworkApi.Models;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("account")]
    public class AccountController : ApiControllerBase
    {
        private readonly AspNetUserManager _aspNetUserManager;

        public AccountController(AspNetUserManager aspNetUserManager)
        {
            _aspNetUserManager = aspNetUserManager;
        }

        // GET api/Account/User
        [Authorize]
        [Route("User")]
        public async Task<UserModel> GetUser()
        {
            return Mapper.Map<AspNetUser, UserModel>(await GetCurrentUser(_aspNetUserManager));
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

            IdentityResult result = await _aspNetUserManager.ChangePasswordAsync(User.Identity.GetUserIdIntPk(), model.OldPassword,
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

            IdentityResult result = await _aspNetUserManager.CreateAsync(user, model.Password);

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
                _aspNetUserManager.Dispose();
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