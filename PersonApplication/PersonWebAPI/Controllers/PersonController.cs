using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace PersonWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _service;

        public PersonController(IPersonService service, ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpPost(Name = "CreatePerson")]
        public async Task<IActionResult> CreatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreatePerson)}");
                return BadRequest(ModelState);
            }

            try
            {
                await _service.CreatePerson(person);
                //TODO: parse to DTO
                return Ok(person);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong.");
                return StatusCode(500, "Internal server error. Pease try again later.");
            }
        }
    }
}
