using System.Security.Cryptography.X509Certificates;
namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public static class Factory
        {
            public static UserEntity CriarUsuario(string email = null, string nome = null)
            {
                return new UserEntity()
                {
                    Email = email,
                    Name = nome
                };
            }
        }
    }

}
