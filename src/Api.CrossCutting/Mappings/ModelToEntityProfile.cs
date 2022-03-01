using System.Security.Cryptography;
using Api.Domain.Entities;
using Api.Domain.Model;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity,UserModel>()
            .ReverseMap();
        }
    }
}
