namespace TollCalculator.Library;

public abstract class VehicleBase
    : IVehicle
{
    public abstract bool IsTollFree();

    public abstract string GetVehicleType();
}