
using System.Net;

namespace URAL.FunctionalTests.CarControllerTests;

public class CarGetActionsTests : BaseFunctionalTestsClass
{
    public CarGetActionsTests(TestApplicationFactory factory) : base(factory, "/api/car/get")
    {
    }

    [Fact]
    public async Task ReturnOkWithJsonOnGetWithCorrectId()
    {
        var response = await Client.GetAsync(requestUri + "/1");

        var actualContent = await response.Content.ReadAsStringAsync();
        var actualContentType = response.Content.Headers.ContentType.MediaType;

        response.EnsureSuccessStatusCode();
        Assert.Contains("json", actualContentType);
        AssertContainsCorrectKeys(actualContent);
    }

    [Fact]
    public async Task ReturnNotFoundOnGetWithWrongId()
    {
        var response = await Client.GetAsync(requestUri + "/0");

        var expected = HttpStatusCode.NotFound;

        Assert.Equal(expected, response.StatusCode);
    }

    //[Fact]
    public async Task ReturnOkWithJsonOnGetAll()
    {
        var response = await Client.GetAsync(requestUri);

        var actualContent = await response.Content.ReadAsStringAsync();
        var actualContentType = response.Content.Headers.ContentType.MediaType;

        response.EnsureSuccessStatusCode();
        Assert.Contains("json", actualContentType);
        AssertContainsCorrectKeys(actualContent);
    }

    private void AssertContainsCorrectKeys(string actualContent)
    {
        Assert.Contains("\"id\":", actualContent);
        Assert.Contains("\"name\":", actualContent);
        Assert.Contains("\"capacity\":", actualContent);
        Assert.Contains("\"volume\":", actualContent);
        Assert.Contains("\"length\":", actualContent);
        Assert.Contains("\"width\":", actualContent);
        Assert.Contains("\"height\":", actualContent);
        Assert.Contains("\"whereFrom\":", actualContent);
        Assert.Contains("\"whereTo\":", actualContent);
        Assert.Contains("\"readyFrom\":", actualContent);
        Assert.Contains("\"readyTo\":", actualContent);
        Assert.Contains("\"phone\":", actualContent);
        Assert.Contains("\"comment\":", actualContent);
        Assert.Contains("\"bodyTypes\":", actualContent);
        Assert.Contains("\"loadingTypes\":", actualContent);
    }
}
