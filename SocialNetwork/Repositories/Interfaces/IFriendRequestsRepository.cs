using DbContext.Entities;

namespace Repositories.Interfaces
{
    public interface IFriendRequestsRepository : ICrudRepositoryBase<FriendRequest, int>
    {
    }
}
