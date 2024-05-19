namespace TollCalculator.UnitTests.TollFee.DateTime;

using FluentAssertions;
using Library.Extensions.TollFee;
using Xunit;
using DateTime = System.DateTime;

public class TollFreeDateTimeExtensionsTests
{
    [Theory]
    [InlineData(2013, 1, 1)] // New Year's Day
    [InlineData(2013, 7, 15)] // Random day in July
    [InlineData(2013, 12, 25)] // Christmas Day
    public void IsTollFree_ShouldReturnTrue_ForTollFreeDates(int year, int month, int day)
    {
        // Arrange
        var date = new DateTime(year, month, day);

        // Act
        var result = date.IsTollFree();

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData(2013, 1, 2)] // Day after New Year's Day

    public void IsTollFree_ShouldReturnFalse_ForNonTollFreeDates(int year, int month, int day)
    {
        // Arrange
        var date = new DateTime(year, month, day);

        // Act
        var result = date.IsTollFree();

        // Assert
        result.Should().BeFalse();
    }
}