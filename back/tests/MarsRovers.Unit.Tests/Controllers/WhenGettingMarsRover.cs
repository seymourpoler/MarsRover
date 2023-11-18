using MarsRover.Controllers;
using MarsRover.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;

namespace MarsRovers.Unit.Tests.Controllers
{
    public class WhenGettingMarsRover
    {
        ILogger<MarsRoversController> logger = Substitute.For<ILogger<MarsRoversController>>();

        [Fact]
        public void ReturnsMarsRover()
        {
            var repository = Substitute.For<IMarsRoversRepository>();
            var controller = new MarsRoversController(repository, logger);

            var response = controller.Get() as OkObjectResult;

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be((int)HttpStatusCode.OK);

        }
    }
}
