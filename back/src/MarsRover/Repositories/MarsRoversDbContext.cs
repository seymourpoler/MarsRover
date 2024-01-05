using Microsoft.EntityFrameworkCore;

namespace MarsRover.Repositories;

public class MarsRoversDbContext : DbContext
{
    public MarsRoversDbContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Situation> Situations{ get; set; }

    public DbSet<Map> Maps { get; set; }

    public DbSet<Obstacle> Obstacles { get; set; }
}