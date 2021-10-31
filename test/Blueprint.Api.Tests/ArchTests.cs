using System.Reflection;
using Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;
using Blueprint.Domain.Entities;
using Blueprint.Infrastructure.Repositories;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Blueprint.Api.Tests;

public class ArchTests
{
    private static readonly Assembly AppAssembly = typeof(GetWeatherForecastsQuery).Assembly;
    private static readonly Assembly DomainAssembly = typeof(WeatherForecast).Assembly;
    private static readonly Assembly InfrastructureAssembly = typeof(WeatherForecastRepo).Assembly;

    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
    {
        // Arrange and Act
        var result = DomainAssembly.CheckIfNotDependsOn(AppAssembly);

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
        // Arrange and Act
        var result = DomainAssembly.CheckIfNotDependsOn(InfrastructureAssembly);

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void InfrastructureLayer_DoesNotHaveDependency_ToApplicationLayer()
    {
        // Arrange and Act
        var result = InfrastructureAssembly.CheckIfNotDependsOn(AppAssembly);

        // Assert
        result.IsSuccessful.Should().BeTrue();
    }
}

public static class ArchTestsExtensions
{
    public static TestResult CheckIfNotDependsOn(this Assembly inAssembly, Assembly assemblyToCheck) =>
        Types.InAssembly(inAssembly)
            .Should()
            .NotHaveDependencyOn(assemblyToCheck.GetName().Name)
            .GetResult();
}
