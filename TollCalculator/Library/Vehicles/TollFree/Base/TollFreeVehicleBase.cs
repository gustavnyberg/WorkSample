namespace TollCalculator.Library.Vehicles.TollFree.Base;

public abstract class TollFreeVehicleBase
    : Vehicle, ITollFreeVehicle
{
    public override bool IsTollFree() 
        => true;

    public override string GetVehicleType() 
        => GetType().Name;
}