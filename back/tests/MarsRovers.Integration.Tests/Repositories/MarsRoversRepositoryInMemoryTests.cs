using DeepEqual.Syntax;
using MarsRover.Repositories;
using Xunit;

namespace MarsRovers.Integration.Tests.Repositories;

public class MarsRoversRepositoryInMemoryTests
{
    [Fact]
    public void Should_Save()
    {
        using (var context = MarsRoversDbContext.Create())
        {
            context.Maps.Add(new Map { Id = Guid.NewGuid(), Horizontal = 3, Vertical = 3, Obstacles = new List<Obstacle>()  });

            var repository = new MarsRoversRepositoryInMemory(context);
            repository.Save(new MarsRover.Domain.Situation(0, 0, "N"));
            var robot = repository.Find();
            robot.Match(
                nothing: null,
                just: robot => { robot.GetSituation().ShouldDeepEqual(new MarsRover.Domain.Situation(0, 0, "N")); return true; });
        }
    }
}