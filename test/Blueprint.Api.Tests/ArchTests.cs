using System.Reflection;
using Blueprint.App.Queries.GetWeatherForecasts;
using Blueprint.Domain.Entities;
using Blueprint.Infrastructure.Repositories;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Blueprint.Api.Tests
{
    public class ArchTests
    {
        private static readonly Assembly AppAssembly = typeof(GetWeatherForecastsQuery).Assembly;
        private static readonly Assembly DomainAssembly = typeof(WeatherForecast).Assembly;
        private static readonly Assembly InfrastructureAssembly = typeof(WeatherForecastRepo).Assembly;

        [Fact]
        public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
        {
            // Arrange and Act
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(AppAssembly.GetName().Name)
                .GetResult();

            // Assert
            result.FailingTypes.Should().BeNullOrEmpty();
        }

        [Fact]
        public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
        {
            // Arrange and Act
            var result = Types.InAssembly(DomainAssembly)
                .Should()
                .NotHaveDependencyOn(InfrastructureAssembly.GetName().Name)
                .GetResult();

            // Assert
            result.FailingTypes.Should().BeNullOrEmpty();
        }

        [Fact]
        public void InfrastructureLayer_DoesNotHaveDependency_ToApplicationLayer()
        {
            // Arrange and Act
            var result = Types.InAssembly(InfrastructureAssembly)
                .Should()
                .NotHaveDependencyOn(AppAssembly.GetName().Name)
                .GetResult();

            // Assert
            result.FailingTypes.Should().BeNullOrEmpty();
        }
    }
}