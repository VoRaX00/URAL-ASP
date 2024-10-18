using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests;

public class BaseFunctionalTestsClass : IClassFixture<TestApplicationFactory>
{
    protected HttpClient Client { get; }
    protected string requestUri { get; }

    public BaseFunctionalTestsClass(TestApplicationFactory factory, string requestUri)
    {
        Client = factory.CreateClient(new WebApplicationFactoryClientOptions() { AllowAutoRedirect = false });
        this.requestUri = requestUri;

        using (var scope = factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<UralDbContext>();
            db.ReinitializeDbForTests();
        };   
    }
}
