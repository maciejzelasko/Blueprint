using System.Net;
using Blueprint.Api.Client;
using Blueprint.Api.IntegrationTests.Infrastructure;
using FluentAssertions;
using Xunit;

namespace Blueprint.Api.IntegrationTests;

[Collection(BlueprintAppCollection.Name)]
public class WeatherForecastTests
{
    public WeatherForecastTests(BlueprintAppFixture fixture)
    {
        Fixture = fixture;
    }

    private BlueprintAppFixture Fixture { get; }

    [Fact]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
    {
        // Arrange
        const int noDays = 7;

        // Act
        var api = Fixture.CreateApi<IWeatherForecastApi>();
        
        var response = await api.GetAsync(noDays, CancellationToken.None);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
