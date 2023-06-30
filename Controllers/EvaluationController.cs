using Microsoft.AspNetCore.Mvc;
using UfjfGoAPI.Domain.DTO.Evaluations;
using UfjfGoAPI.Services;

namespace UfjfGoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly EvaluationService _service;

        public EvaluationController(EvaluationService service)
        {
            this._service = service;
        }

        [HttpPost]
        public IActionResult Post([FromBody] EvaluationCreateRequest postModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = _service.CreateEvaluation(postModel);

            if (response == null)
                return BadRequest(response.Message);

            return Ok(response.Result);
        }

    }
}
