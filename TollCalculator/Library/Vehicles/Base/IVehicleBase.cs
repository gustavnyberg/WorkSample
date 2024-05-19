namespace TollCalculator.Library.Vehicles.Base;

public interface IVehicle
{
    public string GetVehicleType();

    public bool IsTollFree();
}