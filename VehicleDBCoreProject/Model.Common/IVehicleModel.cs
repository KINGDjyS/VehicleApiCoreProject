using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface IVehicleModel
    {
        int VehicleModelId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        int VehicleMakeId { get; set; }
    }
}
