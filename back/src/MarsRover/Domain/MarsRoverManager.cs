using MarsRover.Monad;
using MarsRover.Repositories;

namespace MarsRover.Domain
{
    public interface IMarsRoverManager
    {
        Either<Error, Situation> Move(string movements);
        Either<Error, Situation> FindCurrentSituation();
    }

    public class MarsRoverManager : IMarsRoverManager
    {
        private readonly IMarsRoversRepository marsRoversRepository;

        public MarsRoverManager(IMarsRoversRepository marsRoversRepository)
        {
            this.marsRoversRepository = marsRoversRepository;
        }

        public Either<Error, Situation> Move(string movements)
        {
            return marsRoversRepository.Find()
                .Match<Either<Error, Robot>>(
                    nothing: () => { return Either<Error, Robot>.Error(new Error()); },
                    just: robot => { return Either<Error, Robot>.Success(robot); })
                .Bind(robot => Move(robot, movements))
                .Bind(robot => Save(robot))
                .Match<Either<Error, Situation>>(
                    onError: error => Either<Error, Situation>.Error(error),
                    onSuccess: robot => Either<Error, Situation>.Success(robot.GetSituation())
                );
        }

        private Either<Error, Robot> Move(Robot robot, string movements)
        {
            robot.Move(movements);
            return Either<Error, Robot>.Success(robot);
        }

        private Either<Error, Robot> Save(Robot robot)
        {
            marsRoversRepository.Save(robot.GetSituation());
            return Either<Error, Robot>.Success(robot);
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
