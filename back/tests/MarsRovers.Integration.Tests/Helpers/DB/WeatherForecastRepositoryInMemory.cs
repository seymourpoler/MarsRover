using MarsRover;

namespace MarsRovers.Integration.Tests;

public class WeatherForecastRepositoryInMemory: IWeatherForecastRepository
{
    private readonly WeatherForecastDbContext _context;

    public WeatherForecastRepositoryInMemory(WeatherForecastDbContext context)
    {
        _context = context;
    }

    public void Save(WeatherForecast weatherForecast)
    {
        _context.WeatherForecast.Add(weatherForecast);
        _context.SaveChanges();
    }

    public List<WeatherForecast> GetWeather()
    {
        return _context.WeatherForecast.ToList();
    }
}