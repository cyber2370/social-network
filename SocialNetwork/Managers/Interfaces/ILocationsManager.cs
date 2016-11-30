using System.Collections.Generic;
using System.Threading.Tasks;
using DbContext.Entities;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface ILocationsManager
    {
        Task<IEnumerable<Location>> GetAllLocations();

        Task<Location> GetLocationById(int id);

        Task<Location> AddLocation(Location location);

        Task<Location> UpdateLocation(Location location);

        Task<bool> DeleteLocation(int id);
    }
}
