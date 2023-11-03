namespace MarsRovers.Integration.Tests;

public class WeatherForecastRepositoryTests
{
    [Fact]
    public void Should_Save()
    {
        var options = WeatherForecastDbContext.DbContextOptions();

        using (var context = new WeatherForecastDbContext(options))
        {
            var repository = new MarsRoversRepositoryInMemory(context);
            repository.Save(new WeatherForecastBuilder().Build());
        }

        using (var context = new WeatherForecastDbContext(options))
        {
            var repository = new MarsRoversRepositoryInMemory(context);
            var carriers = repository.GetWeather();
            carriers.Count.Should().Be(1);
        }
    }

}