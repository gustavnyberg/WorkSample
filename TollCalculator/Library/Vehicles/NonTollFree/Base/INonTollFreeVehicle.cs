namespace TollCalculator.Library.Vehicles.NonTollFree.Base;

public interface INonTollFreeVehicle
{
    bool IsTollFree();
    string GetVehicleType();
}