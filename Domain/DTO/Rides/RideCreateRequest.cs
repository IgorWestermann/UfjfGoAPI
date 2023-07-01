using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.DTO.Rides
{
    public class RideCreateRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(1, 4, ErrorMessage = "Value must be between 1 and 4")]
        public int Vagas { get; set; } = 1;

        [Required]
        public string? From { get; set; }

        [Required]
        public string? Destination { get; set; }

        public bool OnlyWoman { get; set; } = false;
    }
}
