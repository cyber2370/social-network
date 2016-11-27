using System;
using AutoMapper;
using DbContext.Entities;
using DbContext.Entities.AspNet;
using Managers.Models;
using Managers.Models.AspNet;
using Managers.Models.Friends;

namespace Managers
{
    public static class AutoMapperWebConfiguration
    {
        public static IMapperConfigurationExpression Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserProfile, UserProfileModel>()
                .ForMember(dest => dest.AvatarUri, x => x.MapFrom(src => new Uri(src.AvatarUri)))
                .ReverseMap();

            cfg.CreateMap<Location, LocationModel>()
                .ReverseMap();

            cfg.CreateMap<Workplace, WorkplaceModel>()
                .ReverseMap();

            cfg.CreateMap<Message, MessageModel>()
                .ReverseMap();

            cfg.CreateMap<FriendRequest, FriendRequestModel>()
                .ForMember(dest => dest.IsConfirmed, x => x.MapFrom(src => src.ConfirmedDateTime != null)).
                ReverseMap();

            cfg.CreateMap<UserProfileModel, FriendModel>()
                .ReverseMap();

            cfg.CreateMap<UserWorkplace, UserWorkplaceModel>()
                .ForMember(dest => dest.IsCurrentWorkplace, x => x.MapFrom(src => src.EndWorkDate != null))
                .ReverseMap();

            cfg.CreateMap<AspNetUser, AspNetUserModel>()
                .ReverseMap();

            return cfg;
        }
    }
}
