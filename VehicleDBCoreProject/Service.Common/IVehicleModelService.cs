using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetVehicleModelAsync(int id);
        Task<List<IVehicleModel>> GetVehicleModelsAsync(Filtering filtering, Sorting sorting, Paging paging);
        Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel newModel);
        Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel changedModel);
        Task<IVehicleModel> DeleteVehicleModelAsync(int id);
        Task<bool> ModelExists(int id);
    }
}
