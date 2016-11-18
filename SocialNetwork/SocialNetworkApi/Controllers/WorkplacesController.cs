﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;

namespace SocialNetworkApi.Controllers
{
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
        public async Task<IEnumerable<WorkplaceModel>> GetAllWorkplaces()
        {
            return await _workplacesManager.GetAllWorkplaces();
        }

        [HttpGet]
        public async Task<WorkplaceModel> GetWorkplace(int id)
        {
            return await _workplacesManager.GetWorkplaceById(id);
        }

        [HttpGet]
        [Route("{workplaceId}/users/")]
        public async Task<IEnumerable<UserWorkplaceModel>> GetWorkplaceUsers(int workplaceId)
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