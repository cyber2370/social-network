using System;
using AutoMapper;
using DbContext.Entities;
using Managers.Models;
using Managers.Models.Friends;

namespace Managers
{
    internal static class MapperInitializer
    {
        private static bool _wasItInitialized;

        internal static void CreateMap()
        {
            if (_wasItInitialized)
                return;

            _wasItInitialized = true;

            Mapper.Initialize(um => um.CreateMap<User, UserModel>()
            .ForMember(dest => dest.AvatarUri, x => x.MapFrom(src => new Uri(src.AvatarUri))));

            Mapper.Initialize(um => um.CreateMap<Location, LocationModel>());

            Mapper.Initialize(um => um.CreateMap<Workplace, WorkplaceModel>());

            Mapper.Initialize(um => um.CreateMap<Message, MessageModel>());

            Mapper.Initialize(um => um.CreateMap<FriendRequest, FriendRequestModel>()
            .ForMember(dest => dest.IsConfirmed, x => x.MapFrom(src => src.ConfirmedDateTime != null)));

            Mapper.Initialize(um => um.CreateMap<UserModel, FriendModel>());

            Mapper.Initialize(um => um.CreateMap<UserWorkplace, UserWorkplaceModel>()
                        .ForMember(dest => dest.IsCurrentWorkplace, x => x.MapFrom(src => src.EndWorkDate != null)));
        }
    }
}
