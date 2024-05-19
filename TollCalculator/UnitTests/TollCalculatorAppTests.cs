namespace TollCalculator.UnitTests;

using System;
using FakeItEasy;
using FluentAssertions;
using Library;
using TollCalculator.Library.Services.Calculator;
using TollCalculator.Library.Vehicles.Base;
using Xunit;

public class TollCalculatorAppTests
{
    [Fact]
    public void GetTollFee_ShouldReturnCorrectFee()
    {
        // Arrange
        var tollCalculatorService = A.Fake<ITollCalculatorService>();
        var tollCalculatorApp = new TollCalculatorApp(tollCalculatorService);
        var vehicle = A.Fake<VehicleBase>();
        var dates = new[] { new DateTime(2022, 1, 3, 7, 0, 0) };
        var expectedFee = 18;

        A.CallTo(() => tollCalculatorService.GetTollFee(vehicle, dates)).Returns(expectedFee);

        // Act
        var fee = tollCalculatorApp.GetTollFee(vehicle, dates);

        // Assert
        fee.Should().Be(expectedFee);
    }

    [Fact]
    public void GetTollFee_ShouldCallServiceWithCorrectParameters()
    {
        // Arrange
        var tollCalculatorService = A.Fake<ITollCalculatorService>();
        var tollCalculatorApp = new TollCalculatorApp(tollCalculatorService);
        var vehicle = A.Fake<VehicleBase>();
        var dates = new[] { new DateTime(2022, 1, 3, 7, 0, 0) };

        // Act
        tollCalculatorApp.GetTollFee(vehicle, dates);

        // Assert
        A.CallTo(() => tollCalculatorService.GetTollFee(vehicle, dates)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public void GetTollFee_ShouldHandleEmptyDatesArray()
    {
        // Arrange
        var tollCalculatorService = A.Fake<ITollCalculatorService>();
        var tollCalculatorApp = new TollCalculatorApp(tollCalculatorService);
        var vehicle = A.Fake<VehicleBase>();
        var dates = Array.Empty<DateTime>();
        var expectedFee = 0;

        A.CallTo(() => tollCalculatorService.GetTollFee(vehicle, dates)).Returns(expectedFee);

        // Act
        var fee = tollCalculatorApp.GetTollFee(vehicle, dates);

        // Assert
        fee.Should().Be(expectedFee);
    }
}