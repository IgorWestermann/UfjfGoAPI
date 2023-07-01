using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.DTO.Rides
{
    public class RideUpdateRequest
    {
        [Required]
        [Range(1, 4)]
        public int Vagas { get; set; }
    }
}
