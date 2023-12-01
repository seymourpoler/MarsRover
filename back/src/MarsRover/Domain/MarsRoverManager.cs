using MarsRover.Monad;
using MarsRover.Repositories;

namespace MarsRover.Domain
{
    public interface IMarsRoverManager
    {
        void Move(string movements);
        Either<Error, Situation> FindCurrentSituation();
    }
    public class MarsRoverManager : IMarsRoverManager
    {
        private readonly IMarsRoversRepository marsRoversRepository;

        public MarsRoverManager(IMarsRoversRepository marsRoversRepository)
        {
            this.marsRoversRepository = marsRoversRepository;
        }

        public void Move(string movements)
        {
            var robot = marsRoversRepository.Find();
            robot.Move(movements);
            marsRoversRepository.Save(robot.GetSituation());
        }

        public Either<Error, Situation> FindCurrentSituation()
        {
            var robot = marsRoversRepository.Find();
            throw new NotImplementedException();
            //return robot.GetSituation();
        }
    }
}
