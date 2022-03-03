using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System;
using AutoMapper;
using Xunit;
using Api.CrossCutting.Mappings;

namespace Api.Service.Test;

public abstract class BaseTesteService
{
    public IMapper Mapper { get; set; }
    public BaseTesteService()
    {
        Mapper = new AutoMapperFixture().GetMapper();
    }
    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityDtoProfile());

            });
            return config.CreateMapper();
        }


        public void Dispose()
        {
        }
    }
}
