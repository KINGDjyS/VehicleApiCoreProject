using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<List<IVehicleMake>> GetVehicleMakersAsync(Filtering filtering, Sorting sorting, Paging paging);
        Task<IVehicleMake> GetVehicleMakerAsync(int id);
        Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker);
        Task<IVehicleMake> UpdateVehicleMakerAsync(IVehicleMake changedMaker);
        Task<IVehicleMake> DeleteVehicleMakerAsync(int id);
        Task<bool> MakerExists(int id);
        
    }
}
