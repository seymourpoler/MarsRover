using DeepEqual.Syntax;
using MarsRover.Domain;
using MarsRover.Monads;
using MarsRover.Repositories;
using NSubstitute;
using Xunit;

namespace MarsRovers.Unit.Tests.Domain;

public class WhenFindingMarsRover
{
    IMarsRoversRepository repository;
    IMarsRoverManager manager;

    public WhenFindingMarsRover()
    {
        repository = Substitute.For<IMarsRoversRepository>();
        manager = new MarsRoverManager(repository);
    }

    [Fact]
    public void ReturnAnErrorIfThereIsNoRobot()
    {
        repository.Find().Returns(Maybe<Robot>.Nothing());

        var result = manager.FindCurrentSituation();

        result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Error(new MarsRover.Domain.Error()));
    }

    [Fact]
    public void ReturnASuccessIfThereIsARobot()
    {
        var aRobot = new Robot(new MarsRover.Domain.Map(3, 3), 0, 0, "N");
        repository.Find().Returns(Maybe<Robot>.Just(aRobot));

        var result = manager.FindCurrentSituation();

        result.ShouldDeepEqual(Either<Error, MarsRover.Domain.Situation>.Success(new MarsRover.Domain.Situation(0, 0, "N")));
    }
}
