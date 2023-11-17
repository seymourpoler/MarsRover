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
        public void ForwardToTheNorthItSavesRobotSituation()
        {
            var robot = new Robot(0, 0 , "N");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "N"));
        }

        [Fact]
        public void BackwardToTheSouthSavesRobotSituation()
        {
            var robot = new Robot(0, 0, "N");
            repository.Find().Returns(robot);

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == -1 && situation.Orientation == "N"));
        }

        [Fact]
        public void ForwardToTheSouthItSavesRobotSituation()
        {
            var robot = new Robot(0, 0, "S");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == -1 && situation.Y == 0 && situation.Orientation == "S"));
        }

        [Fact]
        public void BackwardToTheNorthItSavesRobotSituation()
        {
            var robot = new Robot(0, 0, "S");
            repository.Find().Returns(robot);

            manager.Move("B");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 0 && situation.Y == 1 && situation.Orientation == "S"));
        }

        [Fact]
        public void ForwardToTheEastSavesRobotSituation()
        {
            var robot = new Robot(0, 0, "E");
            repository.Find().Returns(robot);

            manager.Move("F");

            repository.Received().Save(Arg.Is<MarsRover.Domain.Situation>(situation => situation.X == 1 && situation.Y == 0 && situation.Orientation == "E"));
        }
    }
}
