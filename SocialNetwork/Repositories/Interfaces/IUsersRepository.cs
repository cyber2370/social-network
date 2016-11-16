using DbContext.Entities;

namespace Repositories.Interfaces
{
    public interface IUsersRepository : ICrudRepositoryBase<User, int>
    {
    }
}
