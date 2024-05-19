namespace TollCalculator.UnitTests.TollFee.Extensions
{
    using System;
    using FluentAssertions;
    using Library.Extensions.TollFee;
    using Xunit;

    public class TollFeeExtensionsTests
    {
        [Fact]
        public void IsTollFree_Weekend_ReturnsTrue()
        {
            // Arrange
            var date = new DateOnly(2023, 1, 1); // Sunday
            // Act
            var result = date.IsTollFree();
            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsTollFree_FixedTollFreeDate_ReturnsTrue()
        {
            // Arrange
            var date = new DateOnly(2013, 1, 1); // New Year's Day
            // Act
            var result = date.IsTollFree();
            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsTollFree_RegularDay_ReturnsFalse()
        {
            // Arrange
            var date = new DateOnly(2023, 1, 2); // Monday
            // Act
            var result = date.IsTollFree();
            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsTollFree_JulyDate_ReturnsTrue()
        {
            // Arrange
            var date = new DateOnly(2013, 7, 15); // A date in July
            // Act
            var result = date.IsTollFree();
            // Assert
            result.Should().BeTrue();
        }
    }
}