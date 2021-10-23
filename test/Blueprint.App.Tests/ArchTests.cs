using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;
using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Xunit;

namespace Blueprint.App.Tests
{
    public class ArchTests
    {
        private static readonly Assembly AppAssembly = typeof(GetWeatherForecastsQuery).Assembly;

        [Fact]
        public void CommandsAndQueries_ShouldBeImmutable()
        {
            // Arrange and Act
            var types = Types.InAssembly(AppAssembly)
                .That().ImplementInterface(typeof(IRequest<>))
                .GetTypes();

            // Assert
            types.ShouldBeImmutable();
        }

        [Fact]
        public void CommandAndQueryHandlers_ShouldNotBePublic()
        {
            // Arrange and Act
            var result = Types.InAssembly(AppAssembly)
                .That()
                .ImplementInterface(typeof(IRequestHandler<>))
                .Should().NotBePublic().GetResult();

            result.IsSuccessful.Should().BeTrue();
        }
    }

    public static class ArchTestsExtensions
    {
        public static void ShouldBeImmutable(this IEnumerable<Type> types)
        {
            var failingTypes = new List<Type>();
            foreach (var type in types)
                if (IsImmutable(type) == false)
                {
                    failingTypes.Add(type);
                    break;
                }

            failingTypes.Should().BeEmpty();
        }

        private static bool IsImmutable(this Type type) =>
            type.GetFields().All(x => x.IsInitOnly) && type.GetProperties().All(x => x.CanWrite == false);
    }
}