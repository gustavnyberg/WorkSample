﻿namespace TollCalculator.Library.Vehicles.TollFree.Base;

using Vehicles.Base;

public abstract class TollFreeVehicleBase
    : VehicleBase, ITollFreeVehicle
{
    public override bool IsTollFree() 
        => true;

    public override string GetVehicleType() 
        => GetType().Name;
}