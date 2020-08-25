namespace Vehicle.Model.Common
{
    public interface IVehicleModel
    {
        int VehicleModelId { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        int VehicleMakeId { get; set; }
    }
}
