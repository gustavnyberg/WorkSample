namespace TollCalculator.Library;

using Vehicles.Base;

public interface ITollCalculatorApp
{
    /**
    * Calculate the total toll fee for one day
    *
    * @param vehicle - the vehicle
    * @param dates   - date and time of all passes on one day
    * @return - the total toll fee for that day
    */
    int GetTollFee(VehicleBase vehicle, DateTime[] dates);
}