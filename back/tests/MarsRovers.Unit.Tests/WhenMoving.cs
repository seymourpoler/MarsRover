using MarsRover.Domain;
using MarsRover.Repositories;
using NSubstitute;

namespace MarsRovers.Unit.Tests
{
    public class WhenMoving
    {
        IMarsRoversRepository repository;
        MarsRoverManager manager;

        public WhenMoving()
        {
            repository = Substitute.For<IMarsRoversRepository>();
            manager = new MarsRoverManager(repository);
        }

        [Fact]
        public void ForwardToTheNorth()
        {
            var robot = new Robot(0, 0 , "N");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "N"));
        }

        [Fact]
        public void BackwardToTheSouth()
        {
            var robot = new Robot(0, 0, "N");
            repository.Find().Returns(robot);

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == -1 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardToTheSouth()
        {
            var robot = new Robot(0, 0, "S");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == -1 && situation.Orientation == "S"));
        }

        [Fact]
        public void BackwardToTheNorth()
        {
            var robot = new Robot(0, 0, "S");
            repository.Find().Returns(robot);

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "S"));
        }

        [Fact]
        public void ForwardToTheEast()
        {
            var robot = new Robot(0, 0, "E");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "E"));
        }

        [Fact]
        public void BackwardToTheWest()
        {
            var robot = new Robot(0, 0, "E");
            repository.Find().Returns(robot);

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == -1 && situation.Y == 0 && situation.Orientation == "E"));
        }

        [Fact]
        public void ForwardToTheWest()
        {
            var robot = new Robot(0, 0, "W");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == -1 && situation.Y == 0 && situation.Orientation == "W"));
        }

        [Fact]
        public void BackwardToTheEast()
        {
            var robot = new Robot(0, 0, "W");
            repository.Find().Returns(robot);

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "W"));
        }

        [Fact]
        public void ForwardToTheNorthFromEastOrientation()
        {
            var robot = new Robot(0, 0, "E");
            repository.Find().Returns(robot);

            manager.Move("NF");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "N"));
        }

        [Fact]
        public void BackwardToTheSouthFromWestOrientation()
        {
            var robot = new Robot(0, 0, "W");
            repository.Find().Returns(robot);

            manager.Move("NB");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == -1 && situation.Orientation == "N"));
        }
    }
}
