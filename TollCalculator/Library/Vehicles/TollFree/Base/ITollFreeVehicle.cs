namespace TollCalculator.Library.Vehicles.TollFree.Base;

public interface ITollFreeVehicle
{
    bool IsTollFree();
    string GetVehicleType();
}