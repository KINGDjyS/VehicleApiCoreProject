using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleMake : IVehicleMake
    {
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
