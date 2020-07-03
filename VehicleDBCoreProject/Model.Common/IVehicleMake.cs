using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Common
{
    public interface IVehicleMake
    {
        int VehicleMakeId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
