using MarsRover.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MarsRover.Repositories;

public class MarsRoversDbContext : DbContext
{
    public MarsRoversDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<MarsRoversRequest> marsRovers { get; set; }
    public DbSet<Situation> Situations{ get; set; }
}