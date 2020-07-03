using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Common;

namespace Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetVehicleModelAsync(int id);
        Task<List<IVehicleModel>> GetVehicleModelsAsync();
        Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel newModel);
        Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel changedModel);
        Task<IVehicleModel> DeleteVehicleModelAsync(int id);
        Task<bool> ModelExists(int id);
    }
}
