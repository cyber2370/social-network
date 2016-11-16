using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class UsersRepository : CrudRepositoryBase<User, string>, IUsersRepository
    {
        public UsersRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.Users)
        {
        }

        protected override Expression<Func<User, bool>> KeyPredicate(string email) =>
            user => user.Email == email;
    }
}
