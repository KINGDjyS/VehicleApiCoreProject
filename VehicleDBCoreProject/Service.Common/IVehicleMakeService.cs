using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMake> GetVehicleMakerAsync(int id);
        Task<List<IVehicleMake>> GetVehicleMakersAsync(Filtering filtering, Sorting sorting, Paging paging);
        Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker);
        Task<IVehicleMake> UpdateVehicleMakerAsync(int id, IVehicleMake changedMaker);
        Task<int> DeleteVehicleMakerAsync(int id);
        Task<bool> MakerExists(int id);
    }
}
