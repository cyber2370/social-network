using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class UserProfilesRepository : CrudRepositoryBase<UserProfile, string>, IUserProfilesRepository
    {
        public UserProfilesRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.UserProfiles)
        {
        }

        protected override Expression<Func<UserProfile, bool>> KeyPredicate(string id) =>
            user => user.UserId == id;
    }
}
