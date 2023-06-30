using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.DTO.Evaluations
{
    public class EvaluationCreateRequest
    {
        [Required]
        public int IdUser { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
        public int Rate { get; set; }
    }
}
