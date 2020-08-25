using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class ServiceDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>();
        }
    }
}
