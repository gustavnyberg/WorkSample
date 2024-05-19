namespace TollCalculator.Library.Services.Calculator;

using Vehicles.Base;

public interface ITollCalculatorService
{
    int GetTollFee(IVehicle vehicle, DateTime[] dates);
}