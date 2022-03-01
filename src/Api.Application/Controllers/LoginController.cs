using System.Net;
using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;


namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (loginDto.Equals(null))
            {
                return BadRequest();
            }

            try
            {
                var result = await service.Login(loginDto);
                if (result is null)
                    return NotFound("Usuario não encontrado");

                return Ok(result);

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
