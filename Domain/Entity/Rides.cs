using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.Entity
{
    public class Rides
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Vagas { get; set; }

        [Required]
        public string? From { get; set; }

        [Required]
        public string? Destination { get; set; }

        [Required]
        public bool OnlyWoman { get; set; } = false;
    }
}
