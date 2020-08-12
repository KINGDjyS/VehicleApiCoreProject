using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }

        public VehicleModelService(IVehicleModelRepository repository)
        {
            Repository = repository;
        }

        public async Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel newModel)
        {
            return await Repository.AddVehicleModelAsync(newModel);
        }

        public async Task<IVehicleModel> DeleteVehicleModelAsync(int id)
        {
            return await Repository.DeleteVehicleModelAsync(id);
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return await Repository.GetVehicleModelAsync(id);
        }

        public async Task<List<IVehicleModel>> GetVehicleModelsAsync(Filtering filtering, Sorting sorting, Paging paging)
        {
            return await Repository.GetVehicleModelsAsync(filtering, sorting, paging);
        }

        public async Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel changedModel)
        {
            return await Repository.UpdateVehicleModelAsync(changedModel);
        }

        public async Task<bool> ModelExists(int id)
        {
            return await Repository.ModelExists(id);
        }
    }
}
