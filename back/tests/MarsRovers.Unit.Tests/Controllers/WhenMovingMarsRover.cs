using MarsRover.Controllers;
using MarsRover.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;

namespace MarsRovers.Unit.Tests.Controllers
{
    public class WhenMovingMarsRover
    {
        ILogger<MarsRoversController> logger = Substitute.For<ILogger<MarsRoversController>>();
        IMarsRoverManager marsRoverManager = Substitute.For<IMarsRoverManager>();

        [Fact]
        public void MovesMovingMarsRover()
        {
            const string commands = "NEFF";
            var request = new MarsRoversRequest(commands);
            var controller = new MarsRoversController(marsRoverManager, logger);

            var response = controller.Post(request) as OkResult;

            response!.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
