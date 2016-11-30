using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;

namespace SocialNetworkApi.Controllers
{
    [Authorize]
    [RoutePrefix("locations")]
    public class LocationsController : ApiController
    {

        private readonly ILocationsManager _locationsManager;

        public LocationsController(ILocationsManager locationsManager)
        {
            _locationsManager = locationsManager;
        }

        [HttpGet]
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _locationsManager.GetAllLocations();
        }
        
        [HttpGet]
        public async Task<Location> GetLocationById(int id)
        {
            return await _locationsManager.GetLocationById(id);
        }
        
        [HttpPost]
        public async Task<Location> AddLocation([FromBody]Location model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("Invalid model state");
            }

            return await _locationsManager.AddLocation(model);
        }
        
        [HttpPut]
        public async Task<Location> UpdateLocation(int id, [FromBody]Location model)
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