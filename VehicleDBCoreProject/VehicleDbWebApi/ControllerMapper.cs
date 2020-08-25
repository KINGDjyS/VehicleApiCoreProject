using AutoMapper;
using Vehicle.Model;
using Vehicle.VehicleDbWebApi.Controllers;

namespace VehicleDbWebApi
{
    public class ControllerMapper : Profile
    {
        public ControllerMapper()
        {
            CreateMap<VehicleMake, VehicleMakeRest>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelRest>().ReverseMap();
        }
    }
}
