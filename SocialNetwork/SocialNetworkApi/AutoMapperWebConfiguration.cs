using AutoMapper;
using DbContext.Entities.AspNet;
using SocialNetworkApi.Models;

namespace SocialNetworkApi
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                Managers.AutoMapperWebConfiguration.Configure(cfg);

                cfg.CreateMap<ApplicationUser, UserModel>()
                    .ReverseMap();
            });

        }
    }
}
