using DeepEqual.Syntax;
using MarsRover.Domain;
using MarsRover.Monad;
using MarsRover.Repositories;
using NSubstitute;
using Xunit;
using DomainMap = MarsRover.Domain.Map;
using DomainObstacle = MarsRover.Domain.Obstacle;

namespace MarsRovers.Unit.Tests.Domain
{
    public class WhenRobotIsMoving
    {
        IMarsRoversRepository repository;
        MarsRoverManager manager;
        DomainMap map;

        public WhenRobotIsMoving()
        {
            repository = Substitute.For<IMarsRoversRepository>();
            manager = new MarsRoverManager(repository);
            map = new DomainMap(3, 3);
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsNoRobot()
        {
            repository.Find().Returns(Maybe<Robot>.Nothing());

            var result = manager.Move("F");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleForwardingToTheNorth()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(1, 2) });
            var robot = new Robot(map, 1, 1, "N");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("F");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void ForwardToTheNorth()
        {
            var robot = new Robot(map, 1, 1, "N");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 2 && situation.Orientation == "N"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleBackwardToTheSouth()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(1, 0) });
            var robot = new Robot(map, 1, 1, "N");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("B");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void BackwardToTheSouth()
        {
            var map = new DomainMap(3, 3);
            var robot = new Robot(map, 1, 1, "N");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "N"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleForwardToTheSouth()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(1, 0) });
            var robot = new Robot(map, 1, 1, "S");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("F");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void ForwardToTheSouth()
        {
            var robot = new Robot(map, 1, 1, "S");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "S"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleBackwardToTheNorth()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(1, 2) });
            var robot = new Robot(map, 1, 1, "S");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("B");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void BackwardToTheNorth()
        {
            var robot = new Robot(map, 1, 1, "S");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 2 && situation.Orientation == "S"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleForwardToTheEast()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(2, 1) });
            var robot = new Robot(map, 1, 1, "E");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("F");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void ForwardToTheEast()
        {
            var robot = new Robot(map, 1, 1, "E");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 2 && situation.Y == 1 && situation.Orientation == "E"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleBackwardToTheWest()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(0, 1) });
            var robot = new Robot(map, 1, 1, "E");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("B");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void BackwardToTheWest()
        {
            var robot = new Robot(map, 1, 1, "E");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "E"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleForwardToTheWest()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(0, 1) });
            var robot = new Robot(map, 1, 1, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("F");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void ForwardToTheWest()
        {
            var robot = new Robot(map, 1, 1, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "W"));
        }

        [Fact]
        public void ReturnsAnErrorIfThereIsAnObstacleBackwardToTheEast()
        {
            var map = new DomainMap(3, 3, new[] { new DomainObstacle(2, 1) });
            var robot = new Robot(map, 1, 1, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            var result = manager.Move("B");

            repository.DidNotReceive().Save(Arg.Any<MarsRover.Domain.Situation>());
            result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new Error()));
        }

        [Fact]
        public void BackwardToTheEast()
        {
            var robot = new Robot(map, 1, 1, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 2 && situation.Y == 1 && situation.Orientation == "W"));
        }

        [Fact]
        public void ForwardToTheNorthFromEastOrientation()
        {
            var robot = new Robot(map, 1, 1, "E");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("NF");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 2 && situation.Orientation == "N"));
        }

        [Fact]
        public void BackwardToTheSouthFromWestOrientation()
        {
            var robot = new Robot(map, 1, 1, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("NB");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardBeyondTheLowVerticalEdgeThenMoveToTheTopPosition()
        {
            var map = new DomainMap(3, 3);
            var robot = new Robot(map,0, 0, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("NB");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 3 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardBeyondTheHighVerticalEdgeThenMoveToTheBottomPosition()
        {
            var map = new DomainMap(3, 3);
            var robot = new Robot(map, 0, 3, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("NF");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 0 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardBeyondTheLowHorizontalEdgeThenMoveToTheTopPosition()
        {
            var map = new DomainMap(3, 3);
            var robot = new Robot(map, 0, 0, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("EB");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 3 && situation.Y == 0 && situation.Orientation == "E"));
        }

        [Fact]
        public void ForwardBeyondTheHighHorizontalEdgeThenMoveToTheBottomPosition()
        {
            var map = new DomainMap(3, 3);
            var robot = new Robot(map, 3, 0, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("EF");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 0 && situation.Orientation == "E"));
        }
    }
}
