using AutoMapper;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Service
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Vehicle.DAL.Entities.VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<Vehicle.DAL.Entities.VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();

            CreateMap<Vehicle.DAL.Entities.VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<Vehicle.DAL.Entities.VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
        }
    }
}
