using MarsRover.Domain;
using MarsRover.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// using Wke.Invoicing.Stock.Carriers.Application.Repositories;
// using Wke.Invoicing.Stock.Carriers.Infrastructure.Integration.Tests.Helpers.DB;

namespace MarsRovers.Integration.Tests;

public class TestWebApplicationFactory: WebApplicationFactory<Program>
{
    private bool _isDisposed = false;
    private IServiceScope _serviceScope;
    public MarsRoversDbContext dbContext;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        dbContext = MarsRoversDbContext.Create();
        dbContext.Maps.Add(new MarsRover.Repositories.Map { Id = Guid.NewGuid(), Horizontal = 3, Vertical = 3, Obstacles = new List<MarsRover.Repositories.Obstacle>() });
        builder.ConfigureServices(services =>
        {
            services.AddTransient<IMarsRoverManager, MarsRoverManager>();
            services.AddTransient<IMarsRoversRepository, MarsRoversRepositoryInMemory>(x => new MarsRoversRepositoryInMemory(dbContext));
            
        });

        return base.CreateHost(builder);
    }

    protected override void Dispose(bool isDisposing)
    {
        if (_isDisposed)
        {
            return;
        }

        if (isDisposing)
        {
            _serviceScope?.Dispose();
        }

        _isDisposed = true;
        base.Dispose(isDisposing);
    }

    public void ClearDatabase()
    {
        dbContext.ChangeTracker.Clear();
    }
}