using Microsoft.EntityFrameworkCore;

namespace MarsRover.Repositories;

public class MarsRoversDbContext : DbContext
{
    public MarsRoversDbContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Situation> Situations{ get; set; }

    public DbSet<Map> Maps { get; set; }

    public DbSet<Obstacle> Obstacles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Situation>().HasKey(x => x.Id);

        modelBuilder.Entity<Map>().HasKey(x => x.Id);
        modelBuilder.Entity<Map>().HasMany(x => x.Obstacles);

        modelBuilder.Entity<Obstacle>().HasKey(x => x.Id);
        modelBuilder.Entity<Obstacle>().HasOne<Map>();
    }

    public static MarsRoversDbContext Create()
    {
        var options = new DbContextOptionsBuilder<MarsRoversDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .Options;
        return new MarsRoversDbContext(options);
    }
}