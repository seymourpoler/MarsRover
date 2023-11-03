using Microsoft.EntityFrameworkCore;

namespace MarsRover;

public class WeatherForecastDbContext : DbContext
{
    public WeatherForecastDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
}