using Microsoft.AspNetCore.Mvc.Testing;

namespace URAL.FunctionalTests.BodyTypeControllerTests;

public class BodyTypeGetActionsTests : IClassFixture<TestApplicationFactory>
{
    public HttpClient Client { get; }
    public string requestUri = "/api/bodyType/get";

    public BodyTypeGetActionsTests(TestApplicationFactory factory)
    {
        Client = factory.CreateClient(new WebApplicationFactoryClientOptions() { AllowAutoRedirect = false });
    }

    [Fact]
    public async Task ReturnOkWithJsonOnGetWithCorrectId()
    {
        var response = await Client.GetAsync(requestUri);
        response.EnsureSuccessStatusCode();
    }
}
