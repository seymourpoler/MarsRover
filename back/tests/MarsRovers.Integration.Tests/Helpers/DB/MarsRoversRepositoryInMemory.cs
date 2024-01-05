using MarsRover.Controllers;
using MarsRover.Domain;
using MarsRover.Monads;

namespace MarsRovers.Integration.Tests;

public class MarsRoversRepositoryInMemory: IMarsRoversRepository
{
    private readonly WeatherForecastDbContext _context;

    public MarsRoversRepositoryInMemory(WeatherForecastDbContext context)
    {
        _context = context;
    }

    public void Save(MarsRoversRequest marsRoversRequest)
    {
        _context.WeatherForecast.Add(marsRoversRequest);
        _context.SaveChanges();
    }

    public List<MarsRoversRequest> GetWeather()
    {
        return _context.WeatherForecast.ToList();
    }

    public void Save(MarsRover.Domain.Situation situation)
    {
        throw new NotImplementedException();
    }

    Maybe<Robot> IMarsRoversRepository.Find()
    {
        throw new NotImplementedException();
    }
}