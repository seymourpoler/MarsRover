using MarsRover;

namespace MarsRovers.Integration.Tests;

public interface IMarsRoversRepository
{
    void Save(MarsRoversRequest marsRoversRequest);
    List<MarsRoversRequest> GetWeather();
}