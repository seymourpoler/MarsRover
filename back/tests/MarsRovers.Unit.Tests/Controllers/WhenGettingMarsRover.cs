﻿using MarsRover.Controllers;
using MarsRover.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;

namespace MarsRovers.Unit.Tests.Controllers
{
    public class WhenGettingMarsRover
    {
        ILogger<MarsRoversController> logger = Substitute.For<ILogger<MarsRoversController>>();
        IMarsRoverManager marsRoverManager = Substitute.For<IMarsRoverManager>();

        [Fact]
        public void ReturnsMarsRover()
        {
            const int x = 0;
            const int y = 0;
            const string orientation = "N";
            var expecedSituation = new Situation(x, y, orientation);
            marsRoverManager.FindCurrentSituation().Returns(expecedSituation);
            var controller = new MarsRoversController(marsRoverManager, logger);

            var response = controller.Get() as OkObjectResult;

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be((int)HttpStatusCode.OK);
            var currentSituation = response.Value as Situation;
            currentSituation.Should().Be(expecedSituation);

        }
    }
}