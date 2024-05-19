namespace TollCalculator.UnitTests.Vehicles;

using FluentAssertions;
using Library;
using TollCalculator.Library.Vehicles.NonTollFree;
using TollCalculator.Library.Vehicles.TollFree;
using Xunit;

public class TollFeeVehiclesTests
{
    public class VehiclesBaseTests
    {
        [Fact]
        public void IsTollFreeVehicle_ShouldReturnFalse_ForCar()
        {
            // Arrange
            var car = new Car();

            // Act
            var result = car.IsTollFree();

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void IsTollFreeVehicle_ShouldReturnTrue_ForMotorbike()
        {
            // Arrange
            var motorbike = new Motorbike();

            // Act
            var result = motorbike.IsTollFree();

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("Motorbike", true)]
        [InlineData("Tractor", true)]
        [InlineData("Emergency", true)]
        [InlineData("Diplomat", true)]
        [InlineData("Foreign", true)]
        [InlineData("Military", true)]
        [InlineData("Car", false)]
        public void IsTollFreeVehicle_ShouldReturnExpectedResult(string vehicleType, bool expectedResult)
        {
            // Arrange
            VehicleBase vehicle = vehicleType switch
            {
                "Motorbike" => new Motorbike(),
                "Tractor" => new Tractor(),
                "Emergency" => new Emergency(),
                "Diplomat" => new Diplomat(),
                "Foreign" => new Foreign(),
                "Military" => new Military(),
                "Car" => new Car(),
                _ => throw new ArgumentOutOfRangeException(nameof(vehicleType), vehicleType, null)
            };

            // Act
            var result = vehicle.IsTollFree();

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}