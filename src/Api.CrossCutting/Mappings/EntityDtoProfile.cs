using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Model;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityDtoProfile : Profile
    {
        public EntityDtoProfile()
        {
            CreateMap<UserModel, UserEntity>()
            .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
            .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
            .ReverseMap();
        }
    }
}
