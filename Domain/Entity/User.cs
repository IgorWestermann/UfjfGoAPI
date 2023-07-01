using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UfjfGoAPI.Domain.Entity
{
    [Table("Users")]
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [StringLength(60)]
        public string? Email { get; set; }

        [Required]
        [StringLength(255)]
        public string? Password { get; set; }

        [Required]
        [StringLength(11)]
        public string? Matricula { get; set; }

        [Required]
        [StringLength(50)]
        public string? Curso { get; set; }

        [Required]
        [StringLength(11)]
        public string? Phone { get; set; }

        [StringLength(255)]
        public string? Photo { get; set; }

        [StringLength(10)]
        public string? Cnh { get; set; }

        [Required]
        public int User_type_id { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public virtual ICollection<Ride> Rides { get; set; }
    }
}
