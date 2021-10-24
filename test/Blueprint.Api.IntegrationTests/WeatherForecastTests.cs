using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Blueprint.Api.Client;
using Blueprint.Api.IntegrationTests.Infrastructure;
using FluentAssertions;
using Xunit;

namespace Blueprint.Api.IntegrationTests
{
    public class WeatherForecastTests : BaseIntegrationTests<IWeatherForecastApi>
    {
        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Arrange
            const int noDays = 7;

            // Act
            var response = await Api.GetAsync(noDays, CancellationToken.None);

            // Assert
            response.ResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}