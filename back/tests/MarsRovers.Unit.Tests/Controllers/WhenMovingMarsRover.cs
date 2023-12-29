using FluentAssertions;
using MarsRover.Controllers;
using MarsRover.Domain;
using MarsRover.Monad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;
using Xunit;

namespace MarsRovers.Unit.Tests.Controllers
{
    public class WhenMovingMarsRover
    {
        ILogger<MarsRoversController> logger = Substitute.For<ILogger<MarsRoversController>>();
        IMarsRoverManager marsRoverManager = Substitute.For<IMarsRoverManager>();

        [Fact]
        public void ReturnsOk()
        {
            const string commands = "NEFF";
            var request = new MarsRoversRequest(commands);
            var controller = new MarsRoversController(marsRoverManager, logger);
            marsRoverManager.Move(commands).Returns(Either<Error, Situation>.Success(new Situation(3, 2, "E")));

            var response = controller.Post(request) as OkObjectResult;

            response!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public void ReturnsBadRequest()
        {
            const string commands = "NEFF";
            var request = new MarsRoversRequest(commands);
            var controller = new MarsRoversController(marsRoverManager, logger);
            marsRoverManager.Move(commands).Returns(Either<Error, Situation>.Error(new Error()));

            var response = controller.Post(request) as BadRequestObjectResult;

            response!.StatusCode.Should().Be((int)HttpStatusCode.BadRequest);
        }
    }
}
