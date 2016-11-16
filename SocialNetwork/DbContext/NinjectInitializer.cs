using Ninject;

namespace DbContext
{
    public static class NinjectInitializer
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<AppDbContext>().ToSelf();
        }
    }
}
