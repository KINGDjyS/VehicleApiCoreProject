using AutoMapper;
using Model;
using Model.Common;

namespace Service
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<DAL.Entities.VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<DAL.Entities.VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();

            CreateMap<DAL.Entities.VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<DAL.Entities.VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
        }
    }
}
