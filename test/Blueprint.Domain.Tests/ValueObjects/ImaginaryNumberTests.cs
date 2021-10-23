using Blueprint.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Blueprint.Domain.Tests.ValueObjects
{
    public class ImaginaryNumberTests
    {
        [Fact]
        public void SameImaginaryNumbersAreEqual()
        {
            // Arrange
            var imaginaryNumber1 = new ImaginaryNumber(10, 100);
            var imaginaryNumber2 = new ImaginaryNumber(10, 100);

            // Act & Assert
            imaginaryNumber1.Should().Be(imaginaryNumber2);
        }
    }
}