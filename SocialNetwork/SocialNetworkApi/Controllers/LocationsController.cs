﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;

namespace SocialNetworkApi.Controllers
{
    [RoutePrefix("locations")]
    public class LocationsController : ApiController
    {

        private readonly ILocationsManager _locationsManager;

        public LocationsController(ILocationsManager locationsManager)
        {
            _locationsManager = locationsManager;
        }

        [HttpGet]
        public async Task<IEnumerable<LocationModel>> GetLocations()
        {
            return await _locationsManager.GetAllLocations();
        }
        
        [HttpGet]
        public async Task<LocationModel> GetLocationById(int id)
        {
            return await _locationsManager.GetLocationById(id);
        }
        
        [HttpPost]
        public async Task<LocationModel> AddLocation([FromBody]LocationModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("Invalid model state");
            }

            return await _locationsManager.AddLocation(model);
        }
        
        [HttpPut]
        public async Task<LocationModel> UpdateLocation(int id, [FromBody]LocationModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("Invalid model state");
            }

            model.Id = id;

            return await _locationsManager.UpdateLocation(model);
        }

        [HttpDelete]
        public async Task<bool> DeleteLocation(int id)
        {
            return await _locationsManager.DeleteLocation(id);
        }
    }
}