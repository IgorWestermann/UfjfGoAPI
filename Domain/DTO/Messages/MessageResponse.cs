using UfjfGoAPI.Domain.Entity;

namespace UfjfGoAPI.Domain.DTO.Messages
{
    public class MessageResponse
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime When { get; set; }

        public MessageResponse(Message message)
        {
            MessageId = message.MessageId;
            SenderId = message.SenderId;
            ReceiverId = message.ReceiverId;
            Content = message.Content;
            When = message.When;
        }
    }
}
