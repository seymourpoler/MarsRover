using MarsRover;

namespace MarsRovers.Integration.Tests;

public class MarsRoversRepositoryInMemory: IMarsRoversRepository
{
    private readonly WeatherForecastDbContext _context;

    public MarsRoversRepositoryInMemory(WeatherForecastDbContext context)
    {
        _context = context;
    }

    public void Save(MarsRover.MarsRoversRequest marsRoversRequest)
    {
        _context.WeatherForecast.Add(marsRoversRequest);
        _context.SaveChanges();
    }

    public List<MarsRover.MarsRoversRequest> GetWeather()
    {
        return _context.WeatherForecast.ToList();
    }
}