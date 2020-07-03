using System;
using System.Collections.Generic;
using System.Text;
using Model.Common;

namespace Model
{
    public class VehicleMake : IVehicleMake
    {
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
