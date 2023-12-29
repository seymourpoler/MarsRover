using MarsRover.Controllers;
using MarsRover.Domain;
using MarsRover.Monad;
using DomainSituation = MarsRover.Domain.Situation;
using RepositorySituation = MarsRover.Repositories.Situation;

namespace MarsRover.Repositories;

// TODO: REMOVE THIS WHEN THE REAL REPOSITORY IS IMPLEMENTED
public class MarsRoversRepositoryInMemory: IMarsRoversRepository
{
    private readonly MarsRoversDbContext context;

    public MarsRoversRepositoryInMemory(MarsRoversDbContext context)
    {
        this.context = context;
    }

    public void Save(MarsRoversRequest marsRoversRequest)
    {
        context.marsRovers.Add(marsRoversRequest);
        context.SaveChanges();
    }

    public List<MarsRoversRequest> GetWeather()
    {
        return context.marsRovers.ToList();
    }

    public void Save(DomainSituation situation)
    {
        context.Situations.Add(new RepositorySituation { X = situation.X, Y = situation.Y, Orientation = situation.Orientation });
        context.SaveChanges();
    }

    public Maybe<Robot> Find()
    {
        throw new NotImplementedException();
    }
}