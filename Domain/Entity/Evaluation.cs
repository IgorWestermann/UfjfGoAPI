using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.Entity
{
    public class Evaluation
    {
        [Key]
        public int IdEvaluation { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Range(1, 5,
        ErrorMessage = "Value must be between 1 and 5")]
        public int Rate { get; set; }

        [StringLength(140)]
        public string Content { get; set; } = string.Empty;

        public virtual User User { get; set; }
    }
}
