namespace TollCalculator.Library;

public abstract class Vehicle
    : IVehicle
{
    public abstract bool IsTollFree();

    public abstract string GetVehicleType();
}