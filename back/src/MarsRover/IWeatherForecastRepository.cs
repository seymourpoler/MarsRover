using MarsRover;

namespace MarsRovers.Integration.Tests;

public interface IWeatherForecastRepository
{
    void Save(WeatherForecast weatherForecast);
    List<WeatherForecast> GetWeather();
}