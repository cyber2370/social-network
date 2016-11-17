using System;
using AutoMapper;
using DbContext.Entities;
using Managers.Models;
using Managers.Models.Friends;

namespace Managers
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserModel>()
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

                cfg.CreateMap<UserModel, FriendModel>()
                    .ReverseMap();

                cfg.CreateMap<UserWorkplace, UserWorkplaceModel>()
                    .ForMember(dest => dest.IsCurrentWorkplace, x => x.MapFrom(src => src.EndWorkDate != null))
                    .ReverseMap();
            });
        }
    }
}
