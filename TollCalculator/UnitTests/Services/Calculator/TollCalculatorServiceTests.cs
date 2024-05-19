namespace TollCalculator.UnitTests.Services.Calculator;

using FakeItEasy;
using FluentAssertions;
using Library.Services.Calculator;
using Library.Vehicles.NonTollFree;
using Library.Vehicles.TollFree;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

public class TollCalculatorServiceTests : IClassFixture<DependencyInjectionFixture>
{
    public TollCalculatorServiceTests(DependencyInjectionFixture fixture)
    {
        _tollCalculatorService = fixture.ServiceProvider.GetRequiredService<ITollCalculatorService>();

        _fakeCar = A.Fake<Car>();
        A.CallTo(() => _fakeCar.IsTollFree()).Returns(false);

        _fakeMotorbike = A.Fake<Motorbike>();
        A.CallTo(() => _fakeMotorbike.IsTollFree()).Returns(true);
    }

    [Fact]
    public void GetTollFee_ShouldReturnZero_WhenDateIsTollFree()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2013, 7, 1, 7, 15, 0), // July, toll-free month
            new DateTime(2013, 7, 1, 8, 15, 0)
        };

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(0);
    }

    [Fact]
    public void GetTollFee_ShouldReturnZero_WhenPassageIsOutsideChargeableHours()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2022, 1, 3, 5, 15, 0), // Before 6:00
            new DateTime(2022, 1, 3, 18, 45, 0) // After 18:29
        };

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(0);
    }

    [Fact]
    public void GetTollFee_ShouldReturnCorrectFee_ForSinglePassage()
    {
        // Arrange
        var dates = new[] { new DateTime(2022, 1, 3, 7, 15, 0) }; // 18 SEK time slot

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(18);
    }

    [Fact]
    public void GetTollFee_ShouldReturnCorrectFee_ForMultiplePassagesWithinOneHour()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2022, 1, 3, 7, 15, 0), // 18 SEK
            new DateTime(2022, 1, 3, 7, 45, 0)  // 18 SEK, within one hour
        };

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(18);
    }

    [Fact]
    public void GetTollFee_ShouldReturnCorrectFee_ForMultiplePassagesAcrossMoreThanOneHour()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2022, 1, 3, 7, 15, 0), // 18 SEK
            new DateTime(2022, 1, 3, 8, 30, 0)  // 8 SEK, more than one hour later
        };

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(26);
    }

    [Fact]
    public void GetTollFee_ShouldReturnMaxFee_WhenExceedsDailyMaximum()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2022, 1, 3, 7, 0, 0), // 18 SEK
            new DateTime(2022, 1, 3, 8, 1, 0), // 13 SEK
            new DateTime(2022, 1, 3, 15, 30, 0), // 18 SEK
            new DateTime(2022, 1, 3, 17, 0, 0) // 13 SEK
        }; // Total would be 62 SEK without the max fee per day rule

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(60); // Max fee per day is 60 SEK
    }

    [Fact]
    public void GetTollFee_ShouldReturnZero_WhenVehicleIsTollFree()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2022, 1, 3, 8, 0, 0),
            new DateTime(2022, 1, 3, 9, 0, 0)
        };
        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeMotorbike, dates);

        // Assert
        fee.Should().Be(0);
    }

    [Theory]
    [InlineData(6, 0, 8)]
    [InlineData(6, 30, 13)]
    [InlineData(7, 0, 18)]
    [InlineData(8, 0, 13)]
    [InlineData(8, 30, 8)]
    [InlineData(15, 0, 13)]
    [InlineData(15, 30, 18)]
    [InlineData(17, 0, 13)]
    [InlineData(18, 0, 8)]
    public void GetTollFee_ShouldReturnCorrectFee_ForVariousTimes(int hour, int minute, int expectedFee)
    {
        // Arrange
        var dates = new[] { new DateTime(2022, 1, 3, hour, minute, 0) }; // Jan 3, 2022 is a Monday

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(expectedFee);
    }

    [Fact]
    public void GetTollFee_ShouldReturnCorrectFee_ForMultiplePassagesWithinSameFeeBracket()
    {
        // Arrange
        var dates = new[]
        {
            new DateTime(2022, 1, 3, 6, 15, 0), // 8 SEK
            new DateTime(2022, 1, 3, 6, 45, 0)  // 13 SEK
        };

        // Act
        var fee = _tollCalculatorService.GetTollFee(_fakeCar, dates);

        // Assert
        fee.Should().Be(13);
    }

    private readonly ITollCalculatorService _tollCalculatorService;
    private readonly Car _fakeCar;
    private readonly Motorbike _fakeMotorbike;
}