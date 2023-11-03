using MarsRover;
using MarsRovers.Integration.Tests;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WeatherForecastDbContext>(options => options.UseInMemoryDatabase("WeatherForecastDb"));
// builder.Services.AddScoped<IWeatherForecastRepository, SqlCarrierRepository>(); //TODO: Change for this
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepositoryInMemory>(); //TODO: Change for this

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }


// TODO: REMOVE THIS WHEN THE REAL REPOSITORY IS IMPLEMENTED
public class WeatherForecastRepositoryInMemory: IWeatherForecastRepository
{
    private readonly WeatherForecastDbContext _context;

    public WeatherForecastRepositoryInMemory(WeatherForecastDbContext context)
    {
        _context = context;
    }

    public void Save(WeatherForecast weatherForecast)
    {
        _context.WeatherForecasts.Add(weatherForecast);
        _context.SaveChanges();
    }

    public List<WeatherForecast> GetWeather()
    {
        return _context.WeatherForecasts.ToList();
    }
}