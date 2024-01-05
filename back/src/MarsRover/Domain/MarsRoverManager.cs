using MarsRover.Monads;

namespace MarsRover.Domain;

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
            .Match(
                nothing: () => { return Either<Error, Robot>.Error(new Error()); },
                just: Either<Error, Robot>.Success)
            .Bind(robot => robot.Move(movements))
            .Bind(Save)
            .Match(
                onError: Either<Error, Situation>.Error,
                onSuccess: robot => Either<Error, Situation>.Success(robot.GetSituation())
            );
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
