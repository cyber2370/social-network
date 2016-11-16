using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Managers.Interfaces;
using Managers.Models;

namespace SocialNetworkApi.Controllers
{
    public class LocationsController : ApiController
    {

        private readonly ILocationsManager _locationsManager;

        public LocationsController(ILocationsManager locationsManager)
        {
            _locationsManager = locationsManager;
        }

        // GET api/<controller>
        public async Task<IEnumerable<LocationModel>> GetLocations()
        {
            return await _locationsManager.GetAllLocations();
        }

        // GET api/<controller>/5
        public async Task<LocationModel> GetLocationById(int id)
        {
            return await _locationsManager.GetLocationById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<LocationModel> AddLocation([FromBody]LocationModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpRequestException("Invalid model state");
            }

            return await _locationsManager.AddLocation(model);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<LocationModel> UpdateLocation(int id, [FromBody]LocationModel model)
        {
            model.Id = id;

            return await _locationsManager.UpdateLocation(model);
        }

        // DELETE api/<controller>/5
        public async Task<bool> Delete(int id)
        {
            return await _locationsManager.DeleteLocation(id);
        }
    }
}