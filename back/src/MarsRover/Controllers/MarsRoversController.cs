using MarsRover.Domain;
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

        return currentSituation.Match<IActionResult>(
            onSuccess: situation => Ok(situation),
            onError: error => BadRequest(error));   
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] MarsRoversRequest marsRoversRequest)
    {
        var result = marsRoverManager.Move(marsRoversRequest.commands)
            .Match<IActionResult>(
            onSuccess: situation => Ok(situation),
            onError: error => BadRequest(error));

        return result;
    }
}