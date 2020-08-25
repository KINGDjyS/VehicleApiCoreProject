using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.VehicleDbWebApi.Controllers
{
    public class VehicleModelRest
    {
        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
