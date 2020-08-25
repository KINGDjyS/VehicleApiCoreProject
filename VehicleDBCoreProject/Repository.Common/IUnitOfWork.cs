using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehicle.DAL;

namespace Vehicle.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Vehicle.DAL.Entities.VehicleMakeEntity> VehicleMakeRepository { get; }
        IRepository<Vehicle.DAL.Entities.VehicleModelEntity> VehicleModelRepository { get; }
        Task<int> CommitAsync();
        void CreateMakerRepository();
        void CreateModelRepository();
    }
}
