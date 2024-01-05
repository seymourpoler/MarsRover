using MarsRover.Domain;
using MarsRover.Monads;
using DomainSituation = MarsRover.Domain.Situation;
using RepositorySituation = MarsRover.Repositories.Situation;

namespace MarsRover.Repositories;

// TODO: REMOVE THIS WHEN THE REAL REPOSITORY IS IMPLEMENTED
public class MarsRoversRepositoryInMemory : IMarsRoversRepository
{
    private readonly MarsRoversDbContext context;

    public MarsRoversRepositoryInMemory(MarsRoversDbContext context)
    {
        this.context = context;
    }

    public void Save(DomainSituation situation)
    {
        context.Situations.Add(new RepositorySituation { X = situation.X, Y = situation.Y, Orientation = situation.Orientation });
        context.SaveChanges();
    }

    public Maybe<Robot> Find()
    {
        var map = context.Maps.FirstOrDefault();
        if(map is null)
            return Maybe<Robot>.Nothing();

        var situation = context.Situations.LastOrDefault();
        if (situation is null)
            return Maybe<Robot>.Nothing();

        var robot = new Robot(BuildMap(map),  situation.X, situation.Y, situation.Orientation);
        return Maybe<Robot>.Just(robot);
    }

    private MarsRover.Domain.Map BuildMap(Map map)
    {
        return new MarsRover.Domain.Map(
            Vertical: map.Vertical,
            Horizontal: map.Horizontal,
            obstacles: map.Obstacles.Select(x => new MarsRover.Domain.Obstacle(x.X, x.Y)).ToArray()
        );
    }
}