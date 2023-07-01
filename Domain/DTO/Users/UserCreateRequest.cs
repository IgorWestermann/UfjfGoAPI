using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.DTO.Users
{
    public class UserCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Matricula { get; set; }

        [Required]
        public string? Curso { get; set; }

        [Required]
        public string? Phone { get; set; }

        public string? Photo { get; set; }

        public string? Cnh { get; set; }

        public int User_type_id { get; set; } = 1;


    }
}
