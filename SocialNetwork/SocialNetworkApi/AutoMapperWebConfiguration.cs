using System;
using AutoMapper;
using DbContext.Entities;
using DbContext.Entities.AspNet;
using Managers.Models;
using Managers.Models.AspNet;
using Managers.Models.Friends;
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

                cfg.CreateMap<AspNetUser, UserModel>()
                    .ReverseMap();
            });

        }
    }
}
