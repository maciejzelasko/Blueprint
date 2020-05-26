using System;
using System.Linq;
using System.Reflection;
using Blueprint.Domain.Entities;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace Blueprint.Domain.Tests
{
    public class ArchTests
    {
        private static readonly Assembly DomainAssembly = typeof(Entity).Assembly;

        [Fact]
        public void Entity_ShouldHaveParameterlessPrivateConstructor()
        {
            // Arrange
            var entityTypes = Types.InAssembly(DomainAssembly)
                .That()
                .Inherit(typeof(Entity)).GetTypes();

            // Act
            var failingTypes =
                from entityType in entityTypes
                let hasPrivateParameterlessConstructor = entityType.HasPrivateParameterlessConstructor()
                where !hasPrivateParameterlessConstructor
                select entityType;

            // Assert
            failingTypes.Should().BeNullOrEmpty();
        }
    }

    public static class ArchTestsExtensions
    {
        public static bool HasPrivateParameterlessConstructor(this Type type)
        {
            var hasPrivateParameterlessConstructor = false;
            var constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var constructorInfo in constructors)
                if (constructorInfo.IsPrivate && constructorInfo.GetParameters().Length == 0)
                    hasPrivateParameterlessConstructor = true;

            return hasPrivateParameterlessConstructor;
        }
    }
}