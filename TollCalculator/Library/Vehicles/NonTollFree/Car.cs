namespace TollCalculator.Library.Vehicles.NonTollFree;

using Base;

public class Car
: NonTollFreeVehicleBase, INonTollFreeVehicle
{
    public override bool IsTollFree()
        => false;
}