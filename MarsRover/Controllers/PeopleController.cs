using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers
{
    [Route("api/v0/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonCreationRequest personCreationRequest)
        {
            return Ok();
        }
    }
}
