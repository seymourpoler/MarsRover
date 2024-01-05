using MarsRover.Controllers;
using MarsRover.Domain;
using MarsRover.Monads;
using DomainSituation = MarsRover.Domain.Situation;


namespace MarsRover.Repositories;

public interface IMarsRoversRepository
{
    void Save(MarsRoversRequest marsRoversRequest);
    void Save(DomainSituation situation);
    List<MarsRoversRequest> GetWeather();
    Maybe<Robot> Find();
}