﻿using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class FriendRequestsRepository : CrudRepositoryBase<FriendRequest, int>, IFriendRequestsRepository
    {
        public FriendRequestsRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.FriendRequests)
        {
        }

        protected override Expression<Func<FriendRequest, bool>> KeyPredicate(int id) =>
            request => request.Id == id;
    }
}
