namespace TollCalculator.UnitTests.Vehicles.Types;

using FakeItEasy;
using FluentAssertions;
using TollCalculator.Library.Vehicles.NonTollFree;
using TollCalculator.Library.Vehicles.TollFree;
using Xunit;

public class VehicleTests
{
    [Fact]
    public void Car_GetVehicleType_ShouldReturnCar()
    {
        // Arrange
        var car = new Car();

        // Act
        var result = car.GetVehicleType();
        // Assert
        result.Should().Be("Car");
    }
    [Fact]
    public void Motorbike_GetVehicleType_ShouldReturnMotorbike()
    {
        // Arrange
        var motorbike = new Motorbike();
        
        // Act
        var result = motorbike.GetVehicleType();
        
        // Assert
        result.Should().Be("Motorbike");
    }

    [Fact]
    public void FakeCar_GetVehicleType_ShouldReturnCar()
    {
        // Arrange
        var fakeCar = A.Fake<Car>();
        A.CallTo(() => fakeCar.GetVehicleType()).Returns("Car");
        
        // Act
        var result = fakeCar.GetVehicleType();
        
        // Assert
        result.Should().Be("Car");
    }
    
    [Fact]
    public void FakeMotorbike_GetVehicleType_ShouldReturnMotorbike()
    {
        // Arrange
        var fakeMotorbike = A.Fake<Car>();
        A.CallTo(() => fakeMotorbike.GetVehicleType()).Returns("Motorbike");
        
        // Act
        var result = fakeMotorbike.GetVehicleType();
        
        // Assert
        result.Should().Be("Motorbike");
    }
}