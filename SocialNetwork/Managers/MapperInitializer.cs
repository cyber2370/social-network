using AutoMapper;
using DbContext.Entities;
using Managers.Models;

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

            Mapper.Initialize(um => um.CreateMap<User, UserModel>());

            Mapper.Initialize(um => um.CreateMap<Location, LocationModel>());

            Mapper.Initialize(um => um.CreateMap<Workplace, WorkplaceModel>());

            Mapper.Initialize(um => um.CreateMap<Message, MessageModel>());

            Mapper.Initialize(um => um.CreateMap<FriendRequest, FriendRequestModel>());

            Mapper.Initialize(um => um.CreateMap<UserWorkplace, UserWorkplaceModel>()
                        .ForMember(dest => dest.IsCurrentWorkplace, x => x.MapFrom(src => src.EndWorkDate != null)));
        }
    }
}
