using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DbContext.Entities;
using Managers.Interfaces;
using Managers.Models;
using Repositories.Interfaces;

namespace Managers.Implementations
{
    internal class LocationsManager : ManagerBase, ILocationsManager
    {
        private readonly ILocationsRepository _locationsRepository;

        public LocationsManager(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            var locations = await _locationsRepository.GetItemsAsync();

            return locations.Select(Mapper.Map<Location, Location>);
        }

        public async Task<Location> GetLocationById(int id)
        {
            Location location = await _locationsRepository.GetItemAsync(id);

            return Mapper.Map<Location, Location>(location);
        }

        public async Task<Location> AddLocation(Location location)
        {
            Location dbLocation = Mapper.Map<Location, Location>(location);

            return Mapper.Map<Location, Location>(await _locationsRepository.AddItemAsync(dbLocation));
        }

        public async Task<Location> UpdateLocation(Location location)
        {
            Location dbLocation = Mapper.Map<Location, Location>(location);

            return Mapper.Map<Location, Location>(await _locationsRepository.UpdateItemAsync(dbLocation));
        }

        public async Task<bool> DeleteLocation(int id)
        {
            try
            {
                await _locationsRepository.RemoveItemAsync(id);
                return true;
            }
            catch
            {
                //TODO: Handle exception
                return false;
            }
        }
    }
}
