﻿namespace Vehicle.Model.Common
{
    public interface IVehicleMake
    {
        int VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
