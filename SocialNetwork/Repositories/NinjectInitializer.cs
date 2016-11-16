using DbContext.Entities;
using Ninject;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace Repositories
{
    public static class NinjectInitializer
    {
        public static void Register(IKernel kernel)
        {
            DbContext.NinjectInitializer.Register(kernel);

            kernel.Bind<IUsersRepository>().To<UsersRepository>();
            kernel.Bind<IWorkplacesRepository>().To<WorkplacesRepository>();
            kernel.Bind<IMessagesRepository>().To<MessagesRepository>();
            kernel.Bind<IUsersWorkplacesRepository>().To<UsersWorkplacesRepository>();
            kernel.Bind<ILocationsRepository>().To<LocationsRepository>();
            kernel.Bind<IFriendRequestsRepository>().To<FriendRequestsRepository>();
        }
    }
}
