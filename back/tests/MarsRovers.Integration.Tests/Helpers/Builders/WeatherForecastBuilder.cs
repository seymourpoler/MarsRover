using MarsRover;

namespace MarsRovers.Integration.Tests;

public class WeatherForecastBuilder
{
    private Guid Id = Guid.NewGuid();
    
    private DateOnly Date = new DateOnly(2021, 1, 1);

    private int TemperatureC = 24;

    private int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    private string? Summary = "Chilly";
    
    public WeatherForecastBuilder WithId(Guid id)
    {
        Id = id;
        return this;
    }
    
    public WeatherForecastBuilder WithDate(DateOnly date)
    {
        Date = date;
        return this;
    }
    
    public WeatherForecastBuilder WithTemperatureC(int temperatureC)
    {
        TemperatureC = temperatureC;
        return this;
    }
    
    public WeatherForecastBuilder WithSummary(string summary)
    {
        Summary = summary;
        return this;
    }
    
    public MarsRover.MarsRoversRequest Build()
    {
        return new MarsRover.MarsRoversRequest
        {
            Id = Id,
            Date = Date,
            TemperatureC = TemperatureC,
            Summary = Summary
        };
    }
}