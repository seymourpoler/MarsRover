using MarsRover.Monads;
using DomainSituation = MarsRover.Domain.Situation;


namespace MarsRover.Domain;

public interface IMarsRoversRepository
{
    void Save(DomainSituation situation);
    Maybe<Robot> Find();
}