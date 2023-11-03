using Microsoft.EntityFrameworkCore;

namespace MarsRover;

public class MarsRoversDbContext : DbContext
{
    public MarsRoversDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<MarsRoversRequest> marsRovers { get; set; }
}