using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }
        public VehicleMakeService(IVehicleMakeRepository repository)
        {
            Repository = repository;
        }
        public async Task<IVehicleMake> GetVehicleMakerAsync(int id)
        {
            return await Repository.GetVehicleMakerAsync(id);
        }

        public async Task<List<IVehicleMake>> GetVehicleMakersAsync(Filtering filtering, Sorting sorting, Paging paging)
        {
            return await Repository.GetVehicleMakersAsync(filtering, sorting, paging);
        }

        public async Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker)
        {
            return await Repository.AddVehicleMakerAsync(newMaker);
        }

        public async Task<IVehicleMake> UpdateVehicleMakerAsync(int id, IVehicleMake changedMaker)
        {
            return await Repository.UpdateVehicleMakerAsync(id, changedMaker);
        }

        public async Task<int> DeleteVehicleMakerAsync(int id)
        {
            await Repository.DeleteVehicleMakerAsync(id);
            return 1;
        }

        public async Task<bool> MakerExists(int id)
        {
            return await Repository.MakerExists(id);
        }
    }
}
