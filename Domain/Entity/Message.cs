using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UfjfGoAPI.Domain.Entity
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        [StringLength(255)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public DateTime When { get; set; }

    }
}
