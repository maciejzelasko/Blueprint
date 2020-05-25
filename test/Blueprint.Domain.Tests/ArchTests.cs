using Blueprint.Domain.Repositories;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Blueprint.Domain.Tests
{
    public class ArchTests
    {
        [Fact]
        public void BlueprintDomain_DoesNotHaveDependency_ToBlueprintInfrastructure()
        {
            // Arrange
            const string infrastructureNamespace = "Blueprint.Infrastructure";

            // Act
            var result = Types.InAssembly(typeof(IWeatherForecastRepo).Assembly)
                .Should()
                .NotHaveDependencyOnAny(infrastructureNamespace)
                .GetResult();

            // Assert
            result.FailingTypes.Should().BeNullOrEmpty();
        }
    }
}