using Blueprint.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Blueprint.Domain.Tests.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void SameAddressesAreEqual()
        {
            // Arrange
            var address1 = Address.Create("Krakowska", "38-100");
            var address2 = Address.Create("Krakowska", "38-100");
            var address3 = Address.Create("Rzeszowska", "38-100");

            // Act
            var address1String = address1.ToString();
            var address2String = address2.ToString();

            // Act & Assert
            address1.Should().Be(address2);
            (address1 == address2).Should().Be(true);
            (address1 == address3).Should().Be(false);
            (address1 != address3).Should().Be(true);
            address1String.Should().Be(address2String);
        }
    }
}