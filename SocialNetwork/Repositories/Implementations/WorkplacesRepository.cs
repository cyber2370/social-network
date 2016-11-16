using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class WorkplacesRepository : CrudRepositoryBase<Workplace, int>, IWorkplacesRepository
    {
        public WorkplacesRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.Workplaces)
        {
        }

        protected override Expression<Func<Workplace, bool>> KeyPredicate(int id) =>
            workplace => workplace.Id == id;
    }
}
