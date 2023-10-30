using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarsRover.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandController : ControllerBase
    {
        [HttpPost]
        public IActionResult ExecuteCommand([FromBody] CommandRequest commandRequest)
        {
            throw new NotImplementedException();
        }
    }
}
