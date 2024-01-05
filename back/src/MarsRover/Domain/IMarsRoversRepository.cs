using MarsRover.Controllers;
using MarsRover.Monads;
using DomainSituation = MarsRover.Domain.Situation;


namespace MarsRover.Domain;

public interface IMarsRoversRepository
{
    void Save(MarsRoversRequest marsRoversRequest);
    void Save(DomainSituation situation);
    List<MarsRoversRequest> GetWeather();
    Maybe<Robot> Find();
}