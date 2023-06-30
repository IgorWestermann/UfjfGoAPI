using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.DTO.Users
{
    public class UserUpdateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Senha é obrigatória")]
        public string? Password { get; set; }
        public string? Photo { get; set; }
        public string? Cnh { get; set; }
    }
}
