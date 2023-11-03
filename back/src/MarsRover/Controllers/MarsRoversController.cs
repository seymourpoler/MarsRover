using MarsRovers.Integration.Tests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MarsRoversController : ControllerBase
{
    private readonly IMarsRoversRepository _repository;
    private readonly ILogger<MarsRoversController> _logger;

    public MarsRoversController(IMarsRoversRepository repository ,ILogger<MarsRoversController> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<MarsRoversRequest> Get()
    {
        return _repository.GetWeather();
    }
    
    [HttpPost()]
    public IActionResult Post([FromBody] MarsRoversRequest marsRoversRequest)
    {
        var marsRoversResponse = new List<MarsRoversResponse> { new MarsRoversResponse(0,0,"N") };
        return Ok(marsRoversResponse);
        _repository.Save(marsRoversRequest);
        return CreatedAtRoute("GetWeatherForecast", null, null);
    }
}

public record MarsRoversResponse(int x, int y, string direction);