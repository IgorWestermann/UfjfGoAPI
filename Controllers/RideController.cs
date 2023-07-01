using Microsoft.AspNetCore.Mvc;
using UfjfGoAPI.Domain.DTO.Rides;
using UfjfGoAPI.Services;

namespace UfjfGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly RideService _service;

        public RideController(RideService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IEnumerable<RideResponse> Get()
        {
            return _service.Find();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _service.FindById(id);

            if (!response.Success)
                return NotFound(response.Message);

            return Ok(response.Result);
        }

        [HttpGet("user/{id}")]
        public IEnumerable<RideResponse> GetByUserId(int id)
        {
            return _service.FindByUserId(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RideCreateRequest postModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.CreateNewRide(postModel);

            if (response == null)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RideUpdateRequest updateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.Edit(id, updateModel);

            if (response == null)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.Delete(id);

            if (response == null)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }
    }
}
