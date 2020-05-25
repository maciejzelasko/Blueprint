using System;
using System.Collections.Generic;
using System.Reflection;
using Blueprint.Domain.Entities;
using Blueprint.Domain.Repositories;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Blueprint.Domain.Tests
{
    public class ArchTests
    {
        private static readonly Assembly DomainAssembly = typeof(Entity).Assembly;

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

        [Fact]
        public void Entity_Should_Have_Parameterless_Private_Constructor()
        {
            // Arrange
            var entityTypes = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(Entity)).GetTypes();

            // Act
            var failingTypes = new List<Type>();
            foreach (var entityType in entityTypes)
            {
                var hasPrivateParameterlessConstructor = false;
                var constructors = entityType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var constructorInfo in constructors)
                {
                    if (constructorInfo.IsPrivate && constructorInfo.GetParameters().Length == 0)
                    {
                        hasPrivateParameterlessConstructor = true;
                    }
                }

                if (!hasPrivateParameterlessConstructor)
                {
                    failingTypes.Add(entityType);
                }
            }

            // Assert
            failingTypes.Should().BeNullOrEmpty();
        }
    }
}