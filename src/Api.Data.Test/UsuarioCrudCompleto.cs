using System.Collections;
using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Collections.Generic;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTests, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Crud de Usuário")]
        [Trait("Crud", "UserEntity")]
        public async Task RealizarCrud()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                UserImplementation _repostitory = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCreate = await _repostitory.InsertAsync(_entity);
                Assert.NotNull(_registroCreate);
                Assert.Equal(_entity.Email, _registroCreate.Email);
                Assert.Equal(_entity.Name, _registroCreate.Name);
                Assert.False(_registroCreate.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                IEnumerable<UserEntity> _registroAtt = await _repostitory.SelectAsync();
             //   Assert.True(_registroAtt.);
               


            }
        }

    }
}
