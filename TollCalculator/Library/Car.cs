namespace TollCalculator.Library;

using Vehicles.NonTollFree.Base;

public class Car
: NonTollFreeVehicleBase, INonTollFreeVehicle
{
    public override bool IsTollFree()
        => false;
}