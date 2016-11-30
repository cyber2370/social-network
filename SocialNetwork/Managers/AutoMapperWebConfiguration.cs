using System;
using AutoMapper;
using DbContext.Entities;
using DbContext.Entities.AspNet;
using Managers.Models;
using Managers.Models.Friends;

namespace Managers
{
    public static class AutoMapperWebConfiguration
    {
        public static IMapperConfigurationExpression Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Message, MessageModel>()
                .ReverseMap();

            cfg.CreateMap<FriendRequest, FriendRequestModel>()
                .ForMember(dest => dest.IsConfirmed, x => x.MapFrom(src => src.ConfirmedDateTime != null)).
                ReverseMap();

            cfg.CreateMap<UserProfile, FriendModel>()
                .ReverseMap();

            return cfg;
        }
    }
}
