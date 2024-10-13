using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using URAL.Hubs;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests;

public class TestApplicationFactory : WebApplicationFactory<IChatClient>
{
    private readonly string environment = "Development";

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment(environment);

        builder.ConfigureServices(services =>
        {
            //var descriptors = services.Where(d => d.ServiceType == typeof(UralDbContext)).ToList();

            //foreach (var descriptor in descriptors)
            //{
            //    services.Remove(descriptor);
            //};

            var descriptors = services.Where(d => d.ServiceType == typeof(DbContextOptions<UralDbContext>)).ToList();

            foreach (var descriptor in descriptors)
            {
                services.Remove(descriptor);
            };

            services.AddScoped(sp =>
            {
                return new DbContextOptionsBuilder<UralDbContext>()
                    .UseInMemoryDatabase("UralDbContextForTesting")
                    .UseApplicationServiceProvider(sp)
                    .Options;
            });
        });

        return base.CreateHost(builder);
    }
}
