using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vehicle.Repository.Common;
using AutoMapper;
using Vehicle.Model.Common;
using Vehicle.Common;

namespace Vehicle.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IMapper Mapper;

        public VehicleModelRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            UnitOfWork.CreateModelRepository();
            Mapper = mapper;
        }
        public async Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel newModel)
        {
            await UnitOfWork.VehicleModelRepository.Add(Mapper.Map<Vehicle.DAL.Entities.VehicleModelEntity>(newModel));
            await UnitOfWork.CommitAsync();
            return newModel;
        }

        public async Task<int> DeleteVehicleModelAsync(int id)
        {
            var model = UnitOfWork.VehicleModelRepository.GetById(id);
            await UnitOfWork.VehicleModelRepository.Delete(model.Result);
            await UnitOfWork.CommitAsync();
            return 1;
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await UnitOfWork.VehicleModelRepository.GetById(id));
        }

        public async Task<List<IVehicleModel>> GetVehicleModelsAsync(Filtering filtering, Sorting sorting, Paging paging)
        {
            var models = await UnitOfWork.VehicleModelRepository.Get();
            if (!String.IsNullOrEmpty(filtering.SearchName))
            {
                return new List<IVehicleModel>(Mapper.Map<List<IVehicleModel>>(await models.Where(f => f.Name.Contains(filtering.SearchName)).OrderBy(o => o.Name).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
            }
            return new List<IVehicleModel>(Mapper.Map<List<IVehicleModel>>(await SortVehicleModels(models, sorting).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
        }

        private IQueryable<DAL.Entities.VehicleModelEntity>SortVehicleModels(IQueryable<Vehicle.DAL.Entities.VehicleModelEntity> models, Sorting sorting)
        {
            switch (sorting.SortBy)
            {
                case "Abrv Desc":
                    return models.OrderByDescending(o => o.Abrv);
                case "Abrv":
                    return models.OrderBy(o => o.Abrv);
                case "VehicleMakeId Desc":
                    return models.OrderByDescending(o => o.VehicleMakeId);
                case "VehicleMakeId":
                    return models.OrderBy(o => o.VehicleMakeId);
                case "Name Desc":
                    return models.OrderByDescending(o => o.Name);
                default:
                    return models.OrderBy(o => o.Name);
            }
        }

        public async Task<IVehicleModel> UpdateVehicleModelAsync(int id, IVehicleModel changedModel)
        {
            var model = await UnitOfWork.VehicleModelRepository.Update(id, Mapper.Map<Vehicle.DAL.Entities.VehicleModelEntity>(changedModel));
            await UnitOfWork.CommitAsync();
            return Mapper.Map<IVehicleModel>(model);
        }

        public async Task<bool> ModelExists(int id)
        {
            if (await UnitOfWork.VehicleModelRepository.GetById(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
