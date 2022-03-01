using Api.Domain.Dtos.User;
using Api.Domain.Model;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel,UserDto>()
            .ReverseMap();
        }
    }
}
