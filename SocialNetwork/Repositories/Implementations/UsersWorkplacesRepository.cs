using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class UsersWorkplacesRepository : CrudRepositoryBase<UserWorkplace, int>, IUsersWorkplacesRepository
    {
        public UsersWorkplacesRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.UsersWorkplaces)
        {
        }

        protected override Expression<Func<UserWorkplace, bool>> KeyPredicate(int id) =>
            userWorkplace => userWorkplace.Id == id;
    }
}
