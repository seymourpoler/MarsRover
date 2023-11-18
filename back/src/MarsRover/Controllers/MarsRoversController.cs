using MarsRover.Domain;
using MarsRover.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarsRoversController : ControllerBase
{
    private readonly IMarsRoverManager marsRoverManager;
    private readonly ILogger<MarsRoversController> logger;

    public MarsRoversController(IMarsRoverManager marsRoverManager, ILogger<MarsRoversController> logger)
    {
        this.marsRoverManager = marsRoverManager;
        this.logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var currentSituation = marsRoverManager.FindCurrentSituation();
        return Ok(currentSituation);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] MarsRoversRequest marsRoversRequest)
    {
        return Ok(new MarsRoversResponse(0, 1, "N"));

        marsRoverManager.Move(marsRoversRequest.commands);
    }
}

public record MarsRoversResponse(int x, int y, string direction);