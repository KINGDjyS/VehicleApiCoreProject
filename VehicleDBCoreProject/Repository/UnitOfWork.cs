using System;
using System.Threading.Tasks;
using AutoMapper;
using Vehicle.DAL;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IVehicleDBContext Context;

        public IRepository<Vehicle.DAL.Entities.VehicleMakeEntity> VehicleMakeRepository { get; set; }

        public IRepository<Vehicle.DAL.Entities.VehicleModelEntity> VehicleModelRepository { get; set; }

        public UnitOfWork(IVehicleDBContext context)
        {
            Context = context;
        }

        public void CreateMakerRepository()
        {
            VehicleMakeRepository = new GenericRepository<Vehicle.DAL.Entities.VehicleMakeEntity>(Context);
        }

        public void CreateModelRepository()
        {
            VehicleModelRepository = new GenericRepository<Vehicle.DAL.Entities.VehicleModelEntity>(Context);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<int> CommitAsync()
        {
            Context.SaveChangesAsync();
            return Task.FromResult(1);
        }
    }
}
