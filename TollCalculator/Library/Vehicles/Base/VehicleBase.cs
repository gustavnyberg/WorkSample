namespace TollCalculator.Library.Vehicles.Base;

public abstract class VehicleBase
    : IVehicle
{
    public abstract bool IsTollFree();

    public abstract string GetVehicleType();
}