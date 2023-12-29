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
            var maybeRobot = marsRoversRepository.Find();
            maybeRobot.Bind(robot =>
                {
                    robot.Move(movements);
                    marsRoversRepository.Save(robot.GetSituation());
                });
            
        }

        // It is not needed, but in this case I wanted to combine `monad maybe` and `monad either`.
        public Either<Error, Situation> FindCurrentSituation()
        {
            var robot = marsRoversRepository.Find();
            return robot.Match(
                nothing: () => Either<Error, Situation>.Error(new Error()),
                just: robot => Either<Error, Situation>.Success(robot.GetSituation()));
        }
    }
}
