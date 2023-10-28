using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarsRover.Controllers
{
    [Route("api/v0/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }
    }
}
