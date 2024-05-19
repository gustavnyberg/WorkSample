namespace TollCalculator.Library.Vehicles.NonTollFree.Base;

using TollFree.Base;
using Vehicles.Base;

public abstract class NonTollFreeVehicleBase
    : VehicleBase, ITollFreeVehicle
{
    public override bool IsTollFree() 
        => true;

    public override string GetVehicleType()
    {
        return GetType().Name;
    }
}