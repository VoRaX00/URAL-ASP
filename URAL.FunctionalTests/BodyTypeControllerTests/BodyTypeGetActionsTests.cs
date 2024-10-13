using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using URAL.Infrastructure.Context;

namespace URAL.FunctionalTests.BodyTypeControllerTests;

public class BodyTypeGetActionsTests : IClassFixture<TestApplicationFactory>
{
    public HttpClient Client { get; }
    public string requestUri = "/api/bodyType/get";

    public BodyTypeGetActionsTests(TestApplicationFactory factory)
    {
        Client = factory.CreateClient(new WebApplicationFactoryClientOptions() { AllowAutoRedirect = false });

        using (var scope = factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<UralDbContext>();
            db.ReinitializeDbForTests();
        };
    }

    [Fact]
    public async Task ReturnOkWithJsonOnGetWithCorrectId()
    {
        var response = await Client.GetAsync(requestUri + "/1");

        var actualContentObject = await response.Content.ReadAsStringAsync();
        var actualContentType = response.Content.Headers.ContentType.MediaType;

        response.EnsureSuccessStatusCode();
        Assert.Contains("json", actualContentType);
        Assert.Contains("\"id\":", actualContentObject);
        Assert.Contains("\"name\":", actualContentObject);
    }
}
