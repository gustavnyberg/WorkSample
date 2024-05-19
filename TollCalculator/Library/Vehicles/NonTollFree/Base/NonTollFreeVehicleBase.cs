namespace TollCalculator.Library.Vehicles.NonTollFree.Base;

using Library;
using TollFree.Base;


public abstract class NonTollFreeVehicleBase
    : Vehicle, ITollFreeVehicle
{
    public override bool IsTollFree() 
        => true;

    public override string GetVehicleType()
    {
        return GetType().Name; // This will return the type of the derived class
    }
}