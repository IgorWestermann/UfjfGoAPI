using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UfjfGoAPI.Domain.Entity
{
    [Table("Rides")]
    public class Ride
    {
        [Key]
        public int RideId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Value must be between 1 and 4")]
        public int Vagas { get; set; }

        [Required]
        public string? From { get; set; }

        [Required]
        public string? Destination { get; set; }

        public bool OnlyWoman { get; set; } = false;

        public virtual User User { get; set; }
    }
}
