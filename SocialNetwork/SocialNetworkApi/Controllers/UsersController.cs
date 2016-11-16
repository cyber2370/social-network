using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;
using Managers.Models.Friends;

namespace SocialNetworkApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersManager _usersManager;

        public UsersController(
            IUsersManager usersManager)
        {
            _usersManager = usersManager;
        }

        // GET api/<controller>/5
        public async Task<UserModel> GetUser(int id)
        {
            return await _usersManager.GetUserById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<UserModel> RegisterUser([FromBody]UserModel model)
        {
            return await _usersManager.AddUser(model);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<UserModel> UpdateUserInformation(int id, [FromBody]UserModel model)
        {
            model.Id = id;

            return await _usersManager.UpdateUser(model);
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(int id)
        {
            return await _usersManager.DeleteUser(id);
        }
    }
}