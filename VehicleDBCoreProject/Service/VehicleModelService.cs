using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;

namespace Service
{
    public class VehicleModelService : IVehicleModelService
    {
        protected IVehicleModelRepository Repository { get; private set; }
        protected IMapper Mapper;

        public VehicleModelService(IVehicleModelRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel newModel)
        {
            return Mapper.Map<IVehicleModel>(await Repository.AddVehicleModelAsync(Mapper.Map<DAL.Entities.VehicleModelEntity>(newModel)));
        }

        public async Task<IVehicleModel> DeleteVehicleModelAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await Repository.DeleteVehicleModelAsync(id));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await Repository.GetVehicleModelAsync(id));
        }

        public async Task<List<IVehicleModel>> GetVehicleModelsAsync()
        {
            return new List<IVehicleModel>(Mapper.Map<List<IVehicleModel>>(await Repository.GetVehicleModelsAsync()));
        }

        public async Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel changedModel)
        {
            return Mapper.Map<IVehicleModel>(await Repository.UpdateVehicleModelAsync(Mapper.Map<DAL.Entities.VehicleModelEntity>(changedModel)));
        }

        public async Task<bool> ModelExists(int id)
        {
            return await Repository.ModelExists(id);
        }
    }
}
