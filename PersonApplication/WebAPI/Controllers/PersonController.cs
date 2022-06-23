using DataAccessLayer.Data;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.DTOs;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Person controller class.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _service;

        /// <summary>
        /// Person controller constructor.
        /// </summary>
        /// <param name="service">IPersonService interface instance.</param>
        /// <param name="logger">ILogger instance.</param>
        public PersonController(IPersonService service, ILogger<PersonController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// CreatePerson POST method.
        /// </summary>
        /// <param name="person">Person to create.</param>
        /// <returns>Returns IActionResult as async task.</returns>
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
                PersonResultDTO savedPerson = await _service.CreatePerson(person);
                return Ok(savedPerson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong.");
                return StatusCode(500, "Internal server error. Pease try again later.");
            }
        }
    }
}
