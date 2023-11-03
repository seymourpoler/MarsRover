using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

// using Wke.Invoicing.Stock.Carriers.Application.Repositories;
// using Wke.Invoicing.Stock.Carriers.Infrastructure.Integration.Tests.Helpers.DB;

namespace MarsRovers.Integration.Tests;

public class TestWebApplicationFactory: WebApplicationFactory<Program>
{
    private bool _isDisposed = false;
    private IServiceScope _serviceScope;
    private IConfiguration _configuration;
    

    public WeatherForecastDbContext DbContext;

    protected override IHost CreateHost(IHostBuilder builder)
    {
        DbContext = new WeatherForecastDbContext(WeatherForecastDbContext.DbContextOptions());
        builder.ConfigureServices(services =>
        {
            services.AddScoped<IMarsRoversRepository, MarsRoversRepositoryInMemory>(x => new MarsRoversRepositoryInMemory(DbContext));
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

    public async Task ClearDatabase()
    {
        DbContext.ChangeTracker.Clear();
    }
}