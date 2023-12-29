using FluentAssertions;
using MarsRover.Controllers;
using MarsRover.Domain;
using MarsRover.Monad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;
using Xunit;

namespace MarsRovers.Unit.Tests.Controllers;

public class WhenGettingMarsRover
{
    ILogger<MarsRoversController> logger;
    IMarsRoverManager marsRoverManager;
    MarsRoversController controller;

    public WhenGettingMarsRover()
    {
        logger = Substitute.For<ILogger<MarsRoversController>>();
        marsRoverManager = Substitute.For<IMarsRoverManager>();
        controller = new MarsRoversController(marsRoverManager, logger);
    }

    [Fact]
    public void ReturnsMarsRoverSituation()
    {
        const int x = 0;
        const int y = 0;
        const string orientation = "N";
        var expecedSituation = new Situation(x, y, orientation);
        marsRoverManager.FindCurrentSituation().Returns(Either<Error, Situation>.Success(expecedSituation));

        var response = controller.Get() as OkObjectResult;

        response.Should().NotBeNull();
        response!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        var currentSituation = response.Value as Situation;
        currentSituation.Should().Be(expecedSituation);
    }

    [Fact]
    public void ReturnsError()
    {
        var expecedSituation = new Error();
        marsRoverManager.FindCurrentSituation().Returns(Either<Error, Situation>.Error(expecedSituation));
        var controller = new MarsRoversController(marsRoverManager, logger);

        var response = controller.Get() as BadRequestObjectResult;

        response.Should().NotBeNull();
        response!.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        var currentError = response.Value as Error;
        currentError.Should().Be(expecedSituation);
    }
}
