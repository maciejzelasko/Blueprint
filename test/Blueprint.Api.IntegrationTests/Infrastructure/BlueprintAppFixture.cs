using Microsoft.AspNetCore.Mvc.Testing;
using Refit;

namespace Blueprint.Api.IntegrationTests.Infrastructure;

public class BlueprintAppFixture : WebApplicationFactory<Program>
{
    public TApi CreateApi<TApi>()
    {
        var client = CreateClient();
        return RestService.For<TApi>(client);
    }
}
