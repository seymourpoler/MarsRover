using MarsRovers.Integration.Tests.Helpers.Builders;

namespace MarsRovers.Integration.Tests;

public class MarsRoversRepositoryInMemoryTests
{
    [Fact]
    public void Should_Save()
    {
        var options = WeatherForecastDbContext.DbContextOptions();

        using (var context = new WeatherForecastDbContext(options))
        {
            var repository = new MarsRoversRepositoryInMemory(context);
            repository.Save(MarsRoversRequestBuilder.WithCommands("FFFF"));
        }

        using (var context = new WeatherForecastDbContext(options))
        {
            var repository = new MarsRoversRepositoryInMemory(context);
            var carriers = repository.GetWeather();
            carriers.Count.Should().Be(1);
        }
    }

}