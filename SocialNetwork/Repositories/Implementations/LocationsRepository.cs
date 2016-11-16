using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class LocationsRepository : CrudRepositoryBase<Location, int>, ILocationsRepository
    {
        public LocationsRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.Locations)
        {
        }

        protected override Expression<Func<Location, bool>> KeyPredicate(int id) =>
            location => location.Id == id;
    }
}
