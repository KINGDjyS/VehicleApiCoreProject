using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeId { get; set; }
    }
}
