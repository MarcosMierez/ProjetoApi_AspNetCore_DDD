using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDto
    {
        [Required(ErrorMessage = "Nome é um campo requerido")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nome é um email requerido")]
        [StringLength(60, ErrorMessage = "Nome deve ter no maximo {1} caracteres.")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
    }
}
