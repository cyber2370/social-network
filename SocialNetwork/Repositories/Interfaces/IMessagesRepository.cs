using DbContext.Entities;

namespace Repositories.Interfaces
{
    public interface IMessagesRepository : ICrudRepositoryBase<Message, int>
    {

    }
}
