using MarsRover;

namespace MarsRovers.Integration.Tests;

public interface IMarsRoversRepository
{
    void Save(MarsRover.MarsRoversRequest marsRoversRequest);
    List<MarsRover.MarsRoversRequest> GetWeather();
}