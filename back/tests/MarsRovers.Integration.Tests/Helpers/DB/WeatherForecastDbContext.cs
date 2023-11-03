using MarsRover;
using Microsoft.EntityFrameworkCore;

namespace MarsRovers.Integration.Tests;

public class WeatherForecastDbContext: DbContext
{
    public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options)
        : base(options)
    { }

    public DbSet<MarsRover.MarsRoversRequest> WeatherForecast { get; set; }
    
    public static DbContextOptions<WeatherForecastDbContext> DbContextOptions()
    {
        var options = new DbContextOptionsBuilder<WeatherForecastDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;
        return options;
    }
}