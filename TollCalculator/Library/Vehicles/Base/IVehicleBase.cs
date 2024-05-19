namespace TollCalculator.Library;

public interface IVehicle
{
    public string GetVehicleType();

    public bool IsTollFree();
}