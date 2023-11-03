using MarsRover;
using MarsRovers.Integration.Tests;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MarsRoversDbContext>(options => options.UseInMemoryDatabase("WeatherForecastDb"));
// builder.Services.AddScoped<IWeatherForecastRepository, SqlCarrierRepository>(); //TODO: Change for this
builder.Services.AddScoped<IMarsRoversRepository, MarsRoversRepositoryInMemory>(); //TODO: Change for this

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        //builder.WithOrigins("http://localhost:3000") // Agrega el origen de tu frontend
        //       .AllowAnyHeader()
        //       .AllowAnyMethod();

        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

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

app.UseCors();

app.Run();

public partial class Program { }


// TODO: REMOVE THIS WHEN THE REAL REPOSITORY IS IMPLEMENTED
public class MarsRoversRepositoryInMemory: IMarsRoversRepository
{
    private readonly MarsRoversDbContext _context;

    public MarsRoversRepositoryInMemory(MarsRoversDbContext context)
    {
        _context = context;
    }

    public void Save(MarsRover.MarsRoversRequest marsRoversRequest)
    {
        _context.marsRovers.Add(marsRoversRequest);
        _context.SaveChanges();
    }

    public List<MarsRover.MarsRoversRequest> GetWeather()
    {
        return _context.marsRovers.ToList();
    }
}