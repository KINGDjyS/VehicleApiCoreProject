using System;
using System.Collections.Generic;
using System.Text;
using Model.Common;

namespace Model
{
    public class VehicleModel : IVehicleModel
    {
        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
