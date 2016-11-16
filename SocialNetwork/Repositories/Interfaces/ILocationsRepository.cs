using DbContext.Entities;

namespace Repositories.Interfaces
{
    public interface ILocationsRepository : ICrudRepositoryBase<Location, int>
    {
    }
}
