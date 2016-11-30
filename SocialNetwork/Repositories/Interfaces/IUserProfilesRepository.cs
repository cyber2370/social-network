using DbContext.Entities;

namespace Repositories.Interfaces
{
    public interface IUserProfilesRepository : ICrudRepositoryBase<UserProfile, string>
    {
    }
}
