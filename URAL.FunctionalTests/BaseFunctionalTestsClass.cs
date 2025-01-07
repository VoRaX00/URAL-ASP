using Microsoft.AspNetCore.Mvc.Testing;
using URAL.FunctionalTests.Helpers;

namespace URAL.FunctionalTests;

public class BaseFunctionalTestsClass(TestApplicationFactory factory, string requestUri)
    : IClassFixture<TestApplicationFactory>
{
    protected HttpClient Client { get; } = factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
    protected string requestUri { get; } = requestUri;
}
