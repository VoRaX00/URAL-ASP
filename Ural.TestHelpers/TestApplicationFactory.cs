using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data.Common;
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
            var descriptors = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<UralDbContext>));
            services.Remove(descriptors);

            var dbConnection = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));
            services.Remove(dbConnection);

            services.AddSingleton<DbConnection>(container =>
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();

                return connection;
            });

            services.AddDbContext<UralDbContext>((container, options) =>
            {
                var connection = container.GetRequiredService<DbConnection>();
                options.UseSqlite(connection);
            });
        });

        builder.UseEnvironment(environment);

        return base.CreateHost(builder);
    }
}
