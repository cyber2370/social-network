using Managers.Implementations;
using Managers.Interfaces;
using Ninject;

namespace Managers
{
    public static class NinjectInitializer
    {
        public static void Register(IKernel kernel)
        {
            Repositories.NinjectInitializer.Register(kernel);

            kernel.Bind<ApplicationUserManager>().ToSelf();
            kernel.Bind<IUserProfilesManager>().To<UserProfilesManager>();
            kernel.Bind<IWorkplacesManager>().To<WorkplacesManager>();
            kernel.Bind<IMessagesManager>().To<MessagesManager>();
            kernel.Bind<IUsersWorkplacesManager>().To<UsersWorkplacesManager>();
            kernel.Bind<ILocationsManager>().To<LocationsManager>();
            kernel.Bind<IFriendRequestsManager>().To<FriendRequestsManager>();
        }
    }
}
