namespace TollCalculator.Library;

using Services.Calculator;
using Vehicles.Base;

public class TollCalculatorApp(ITollCalculatorService tollCalculatorService)
    : ITollCalculatorApp
{
    /// <summary>
    /// Calculate the total toll fee for one day.
    /// </summary>
    /// <param name="vehicle">The vehicle.</param>
    /// <param name="dates">Date and time of all passes on one day.</param>
    /// <returns>The total toll fee for that day.</returns>
    public int GetTollFee(VehicleBase vehicle, DateTime[] dates) =>
        tollCalculatorService.GetTollFee(vehicle, dates);
}