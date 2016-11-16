using System.Collections.Generic;
using System.Threading.Tasks;
using Managers.Models;

namespace Managers.Interfaces
{
    public interface ILocationsManager
    {
        Task<IEnumerable<LocationModel>> GetAllLocations();

        Task<LocationModel> GetLocationById(int id);

        Task<LocationModel> AddLocation(LocationModel location);

        Task<LocationModel> UpdateLocation(LocationModel location);

        Task<bool> DeleteLocation(int id);
    }
}
