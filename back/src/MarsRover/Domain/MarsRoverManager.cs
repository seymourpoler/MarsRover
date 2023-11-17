using MarsRover.Repositories;

namespace MarsRover.Domain
{
    public class MarsRoverManager
    {
        private readonly IMarsRoversRepository marsRoversRepository;

        public MarsRoverManager(IMarsRoversRepository marsRoversRepository)
        {
            this.marsRoversRepository = marsRoversRepository;
        }

        public void Move(string movements)
        {
            var robot = marsRoversRepository.Find();
            robot.move(movements);
            marsRoversRepository.Save(robot.GetSituation());
        }
    }
}
