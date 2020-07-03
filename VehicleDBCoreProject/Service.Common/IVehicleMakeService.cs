using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Common;

namespace Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMake> GetVehicleMakerAsync(int id);
        Task<List<IVehicleMake>> GetVehicleMakersAsync();
        Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker);
        Task<IVehicleMake> UpdateVehicleMakerAsync(IVehicleMake changedMaker);
        Task<IVehicleMake> DeleteVehicleMakerAsync(int id);
        Task<bool> MakerExists(int id);
    }
}
