using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using Xunit;
using System;
using System.Linq;

namespace Api.Service.Test.Usuario
{
    public class GetUsuarioTest : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;
        public GetUsuarioTest()
        {
            _serviceMock = new Mock<IUserService>();
        }

        [Fact(DisplayName = "Sucesso metodo GET")]
        public async Task Get_MetodoGet_TestandoGet()
        {
            _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);
        }

        [Fact(DisplayName = "Sucesso metodo GETALL")]
        public async Task GetAll_MetodoGetAll_TestandoGetAll()
        {
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUsuario);
            _service = _serviceMock.Object;

            var result = await _service.GetAll() as List<UserDto>;

            Assert.NotNull(result);
            Assert.True(result.Any());
        }
    }
}
