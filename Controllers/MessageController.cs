using Microsoft.AspNetCore.Mvc;
using UfjfGoAPI.Domain.DTO.Messages;
using UfjfGoAPI.Services;

namespace UfjfGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService _service;

        public MessageController(MessageService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] MessageCreateRequest postModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.CreateNewMessage(postModel);

            if (response == null)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

        [HttpGet]
        public IEnumerable<MessageResponse> Get()
        {
            return _service.FindAllMessages();
        }

        [HttpGet("{id}")]
        public IEnumerable<MessageResponse> GetById(int id)
        {
            return _service.GetConversations(id);
        }


    }
}
