using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using MarsRover;

namespace MarsRovers.Integration.Tests;

public class WeatherForecastControllerTests
{
    private readonly TestWebApplicationFactory _application;
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "api/WeatherForecast";
    private readonly WeatherForecastRepositoryInMemory _repository;

    public WeatherForecastControllerTests()
    {
        _application = new TestWebApplicationFactory();
        _httpClient = _application.CreateClient();
        _repository = new WeatherForecastRepositoryInMemory(_application.DbContext);
    }

    [Fact]
    public async Task GetWeather()
    {
        _repository.Save(new WeatherForecastBuilder().Build());
        _repository.Save(new WeatherForecastBuilder().Build());

        var response = await _httpClient.GetAsync($"{BaseUrl}");

        var stringResult = await response.Content.ReadAsStringAsync();
        var carriers = JsonDeserializeContent<List<WeatherForecast>>(stringResult);

        carriers.Should().HaveCount(2);
        response.EnsureSuccessStatusCode();
    }
    
    private static T JsonDeserializeContent<T>(string content)
    {
        return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })?? throw new Exception("Deserialization failed");
    }
    
    private static HttpContent JsonSerializeContent<T>(T content)
    {
        return new StringContent(
            JsonSerializer.Serialize(content),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
    }
}