using System;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        private readonly SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration;

        public LoginService(IUserRepository repository,
                            SigningConfigurations signingConfigurations,
                            TokenConfigurations tokenConfigurations,
                            IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> Login(LoginDto user)
        {
            var baseUser = UserEntity.Factory.CriarUsuario(user.Email);
            if (baseUser != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.Login(user.Email);
                if (baseUser is null)
                    return new { autenticated = false, message = "Falha ao autenticar usuário" };

                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]{
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                         new Claim(JwtRegisteredClaimNames.UniqueName,user.Email)
                        }
                    );

                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);

                    return SuccessObject(createDate, expirationDate, token, user);
                }
            }

            return new { autenticated = false, message = "Falha ao autenticar usuário" };
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(
                new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = createDate,
                    Expires = expirationDate
                });

            var token = handler.WriteToken(securityToken);

            return token;

        }

        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expitation = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                assesToken = token,
                userName = user.Email,
                message = "Usuario logado com sucesso"
            };
        }
    }
}
