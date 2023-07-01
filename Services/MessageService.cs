using UfjfGoAPI.DAL;
using UfjfGoAPI.Domain.DTO.Messages;
using UfjfGoAPI.Domain.Entity;
using UfjfGoAPI.Services.Base;

namespace UfjfGoAPI.Services
{
    public class MessageService
    {
        private readonly AppDbContext _db;

        public MessageService(AppDbContext db)
        {
            this._db = db;
        }

        public ServiceResponse<MessageResponse> CreateNewMessage(MessageCreateRequest model)
        {
            if (model.SenderId == model.ReceiverId)
                return new ServiceResponse<MessageResponse>("Sender cannot be the receiver");

            var newMessage = new Message()
            {
                SenderId = model.SenderId,
                ReceiverId = model.ReceiverId,
                When = DateTime.Now,
                Content = model.Content,
            };

            _db.Messages.Add(newMessage);
            _db.SaveChanges();

            return new ServiceResponse<MessageResponse>(new MessageResponse(newMessage));
        }

        public IEnumerable<MessageResponse> FindAllMessages()
        {
            var result = _db.Messages.ToList();

            IEnumerable<MessageResponse> messages = result.Select(x => new MessageResponse(x));

            return messages;
        }

        public IEnumerable<MessageResponse> GetConversations(int id)
        {
            var result = _db.Messages.Where(message => (message.SenderId == id || message.ReceiverId == id) && message.SenderId != message.ReceiverId).ToList();

            IEnumerable<MessageResponse> conversation = result.Select(x => new MessageResponse(x));

            return conversation;
        }
    }
}
