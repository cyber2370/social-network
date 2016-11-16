using System;
using System.Linq.Expressions;
using DbContext;
using DbContext.Entities;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    internal class MessagesRepository : CrudRepositoryBase<Message, int>, IMessagesRepository
    {
        public MessagesRepository(AppDbContext dbContext) 
            : base(dbContext, dbContext.Messages)
        {
        }

        protected override Expression<Func<Message, bool>> KeyPredicate(int id) =>
            message => message.Id == id;
    }
}
