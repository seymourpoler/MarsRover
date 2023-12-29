using MarsRover.Domain;
using MarsRover.Monad;
using MarsRover.Repositories;
using NSubstitute;
using Xunit;

namespace MarsRovers.Unit.Tests.Domain
{
    public class WhenMoving
    {
        IMarsRoversRepository repository;
        MarsRoverManager manager;
        Map map;

        public WhenMoving()
        {
            repository = Substitute.For<IMarsRoversRepository>();
            manager = new MarsRoverManager(repository);
            map = new Map(3, 3);
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
        public void BackwardToTheSouth()
        {
            var robot = new Robot(map, 1, 1, "N");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "N"));
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
        public void BackwardToTheNorth()
        {
            var robot = new Robot(map, 1, 1, "S");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 2 && situation.Orientation == "S"));
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
        public void BackwardToTheWest()
        {
            var robot = new Robot(map, 1, 1, "E");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "E"));
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
            var map = new Map(3, 3);
            var robot = new Robot(map,0, 0, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("NB");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 3 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardBeyondTheHighVerticalEdgeThenMoveToTheBottomPosition()
        {
            var map = new Map(3, 3);
            var robot = new Robot(map, 0, 3, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("NF");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 0 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardBeyondTheLowHorizontalEdgeThenMoveToTheTopPosition()
        {
            var map = new Map(3, 3);
            var robot = new Robot(map, 0, 0, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("EB");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 3 && situation.Y == 0 && situation.Orientation == "E"));
        }

        [Fact]
        public void ForwardBeyondTheHighHorizontalEdgeThenMoveToTheBottomPosition()
        {
            var map = new Map(3, 3);
            var robot = new Robot(map, 3, 0, "W");
            repository.Find().Returns(Maybe<Robot>.Just(robot));

            manager.Move("EF");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 0 && situation.Orientation == "E"));
        }
    }
}
