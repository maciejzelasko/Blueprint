using Microsoft.AspNetCore.Mvc.Testing;
using RestEase;

namespace Blueprint.Api.IntegrationTests.Infrastructure;

public class BlueprintAppFixture : WebApplicationFactory<Program>
{
    public TApi CreateApi<TApi>()
    {
        var client = CreateClient();
        return RestClient.For<TApi>(client);
    }
}
