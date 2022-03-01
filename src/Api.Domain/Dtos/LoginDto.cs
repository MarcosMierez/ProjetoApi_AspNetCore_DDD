using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}
