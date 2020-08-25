using AutoMapper;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Vehicle.DAL.Entities.VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<Vehicle.DAL.Entities.VehicleMakeEntity, IVehicleMake>().ReverseMap();

            CreateMap<Vehicle.DAL.Entities.VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<Vehicle.DAL.Entities.VehicleModelEntity, IVehicleModel>().ReverseMap();
        }
    }
}
