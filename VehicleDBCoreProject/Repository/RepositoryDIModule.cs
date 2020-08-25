using Autofac;
using Vehicle.DAL;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class RepositoryDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VehicleDBContext>().As<IVehicleDBContext>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().InstancePerLifetimeScope();
        }
    }
}
