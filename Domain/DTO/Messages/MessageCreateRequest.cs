using System.ComponentModel.DataAnnotations;

namespace UfjfGoAPI.Domain.DTO.Messages
{
    public class MessageCreateRequest
    {

        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }
        [Required]
        [StringLength(255)]
        public string Content { get; set; } = string.Empty;

        public DateTime When { get; set; }

    }
}
