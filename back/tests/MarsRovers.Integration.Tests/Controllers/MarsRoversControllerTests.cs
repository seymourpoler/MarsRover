using System.Net.Mime;
using System.Text;
using System.Text.Json;
using DeepEqual.Syntax;
using FluentAssertions;
using MarsRover.Controllers;
using MarsRover.Repositories;
using Xunit;

namespace MarsRovers.Integration.Tests.Controllers;

public class MarsRoversControllerTests
{
    private readonly TestWebApplicationFactory application;
    private readonly HttpClient httpClient;
    private const string BaseUrl = "api/MarsRovers";
    private readonly MarsRoversRepositoryInMemory repository;

    public MarsRoversControllerTests()
    {
        application = new TestWebApplicationFactory();
        httpClient = application.CreateClient();
        repository = new MarsRoversRepositoryInMemory(application.dbContext);
    }

    [Fact]
    public async Task GetWeather()
    {
        repository.Save(new MarsRover.Domain.Situation(0, 0, "N"));
        repository.Save(new MarsRover.Domain.Situation(0, 1, "N"));

        var response = await httpClient.GetAsync($"{BaseUrl}");

        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        var stringResult = await response.Content.ReadAsStringAsync();
        var situation = JsonDeserializeContent<MarsRover.Domain.Situation>(stringResult);

        situation.ShouldDeepEqual(new MarsRover.Domain.Situation(0, 1, "N"));
    }

    private static T JsonDeserializeContent<T>(string content)
    {
        return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Deserialization failed");
    }

    private static HttpContent JsonSerializeContent<T>(T content)
    {
        return new StringContent(
            JsonSerializer.Serialize(content),
            Encoding.UTF8,
            MediaTypeNames.Application.Json);
    }
}