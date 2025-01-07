using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using URAL.Hubs;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests.Helpers;

// ReSharper disable once ClassNeverInstantiated.Global
public class TestApplicationFactory : WebApplicationFactory<IChatClient>
{
    private const string Environment = "Development";
    private static readonly IConfiguration Configuration = new ConfigurationBuilder()
        .AddJsonFile("test_settings.json")
        .Build();
    private static readonly string ConnectionString = Configuration.GetConnectionString(nameof(UralDbContext))!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContextOptions<UralDbContext>>();
            services.RemoveAll<UralDbContext>();

            services.AddDbContext<UralDbContext>(options => options.UseNpgsql(ConnectionString));
        });

        builder.UseEnvironment(Environment);
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        var host = base.CreateHost(builder);

        using var scope = host.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UralDbContext>();

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        context.SeedDatabaseWithTestData();

        return host;
    }
}
