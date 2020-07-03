using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<List<VehicleMakeEntity>> GetVehicleMakersAsync();
        Task<VehicleMakeEntity> GetVehicleMakerAsync(int id);
        Task<VehicleMakeEntity> AddVehicleMakerAsync(VehicleMakeEntity newMaker);
        Task<VehicleMakeEntity> UpdateVehicleMakerAsync(VehicleMakeEntity changedMaker);
        Task<VehicleMakeEntity> DeleteVehicleMakerAsync(int id);
        Task<bool> MakerExists(int id);
        
    }
}
