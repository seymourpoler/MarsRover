using MarsRover.Domain;
using MarsRover.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MarsRoversDbContext>(options => options.UseInMemoryDatabase("MarsRoverDataBase"));
builder.Services.AddScoped<IMarsRoverManager, MarsRoverManager>();
builder.Services.AddScoped<IMarsRoversRepository, MarsRoversRepositoryInMemory>();

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
