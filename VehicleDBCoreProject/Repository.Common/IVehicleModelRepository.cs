using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task<List<VehicleModelEntity>> GetVehicleModelsAsync();
        Task<VehicleModelEntity> GetVehicleModelAsync(int id);
        Task<VehicleModelEntity> AddVehicleModelAsync(VehicleModelEntity newModel);
        Task<VehicleModelEntity> UpdateVehicleModelAsync(VehicleModelEntity changedModel);
        Task<VehicleModelEntity> DeleteVehicleModelAsync(int id);
        Task<bool> ModelExists(int id);

    }
}
