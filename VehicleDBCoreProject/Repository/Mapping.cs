using AutoMapper;

namespace Vehicle.Repository
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DAL.Entities.VehicleMakeEntity, Vehicle.Model.VehicleMake>().ReverseMap();
            CreateMap<DAL.Entities.VehicleMakeEntity, Vehicle.Model.Common.IVehicleMake>().ReverseMap();

            CreateMap<DAL.Entities.VehicleModelEntity, Vehicle.Model.VehicleModel>().ReverseMap();
            CreateMap<DAL.Entities.VehicleModelEntity, Vehicle.Model.Common.IVehicleModel>().ReverseMap();
        }
    }
}
