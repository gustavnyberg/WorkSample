﻿namespace TollCalculator.Library;

using Services.Calculator;
using Vehicles.Base;

public class TollCalculatorApp(ITollCalculatorService tollCalculatorService) : ITollCalculatorApp
{
    /**
    * Calculate the total toll fee for one day
    *
    * @param vehicle - the vehicle
    * @param dates   - date and time of all passes on one day
    * @return - the total toll fee for that day
    */
    public int GetTollFee(VehicleBase vehicle, DateTime[] dates) =>
        tollCalculatorService.GetTollFee(vehicle, dates);
}