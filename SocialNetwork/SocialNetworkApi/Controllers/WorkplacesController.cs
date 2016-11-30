using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("workplaces")]
    public class WorkplacesController : ApiController
    {
        private readonly IWorkplacesManager _workplacesManager;
        private readonly IUsersWorkplacesManager _usersWorkplacesManager;

        public WorkplacesController(
            IWorkplacesManager workplacesManager,
            IUsersWorkplacesManager usersWorkplacesManager)
        {
            _workplacesManager = workplacesManager;
            _usersWorkplacesManager = usersWorkplacesManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Workplace>> GetAllWorkplaces()
        {
            return await _workplacesManager.GetAllWorkplaces();
        }

        [HttpGet]
        public async Task<Workplace> GetWorkplace(int id)
        {
            return await _workplacesManager.GetWorkplaceById(id);
        }

        [HttpGet]
        [Route("{workplaceId}/users/")]
        public async Task<IEnumerable<UserWorkplace>> GetWorkplaceUsers(int workplaceId)
        {
            return await _usersWorkplacesManager.GetUsersWorkplacesByWorkplaceId(workplaceId);
        }

        [HttpDelete]
        public async Task<bool> DeleteWorkplace(int id)
        {
            return await _workplacesManager.DeleteWorkplace(id);
        }
    }
}