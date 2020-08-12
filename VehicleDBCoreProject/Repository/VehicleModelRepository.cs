using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DAL;
using Microsoft.EntityFrameworkCore;
using Vehicle.Repository.Common;
using AutoMapper;
using Vehicle.Model.Common;
using Vehicle.Common;

namespace Vehicle.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected VehicleDBContext Context { get; private set; }
        protected IMapper Mapper;

        public VehicleModelRepository(VehicleDBContext context, IMapper mapper)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Models DBContext");
            }
            Context = context;
            Mapper = mapper;
        }
        public async Task<IVehicleModel> AddVehicleModelAsync(IVehicleModel newModel)
        {
            Context.VehicleModels.Add(Mapper.Map<Vehicle.DAL.Entities.VehicleModelEntity>(newModel));
            await Context.SaveChangesAsync();
            return newModel;
        }

        public async Task<IVehicleModel> DeleteVehicleModelAsync(int id)
        {
            Vehicle.DAL.Entities.VehicleModelEntity model = Context.VehicleModels.Find(id);
            Context.VehicleModels.Remove(model);
            await Context.SaveChangesAsync();
            return Mapper.Map<IVehicleModel>(model);
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {
            return Mapper.Map<IVehicleModel>(await Context.VehicleModels.Where(m => m.VehicleModelId == id).FirstOrDefaultAsync());
        }

        public async Task<List<IVehicleModel>> GetVehicleModelsAsync(Filtering filtering, Sorting sorting, Paging paging)
        {
            if (!String.IsNullOrEmpty(filtering.SearchName))
            {
                return new List<IVehicleModel>(Mapper.Map<List<IVehicleModel>>(await Context.VehicleModels.Where(f => f.Name.Contains(filtering.SearchName)).OrderBy(o => o.Name).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
            }
            return new List<IVehicleModel>(Mapper.Map<List<IVehicleModel>>(await SortVehicleModels(sorting).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
        }

        private IQueryable<DAL.Entities.VehicleModelEntity>SortVehicleModels(Sorting sorting)
        {
            switch (sorting.SortBy)
            {
                case "Abrv Desc":
                    return Context.VehicleModels.OrderByDescending(o => o.Abrv);
                case "Abrv":
                    return Context.VehicleModels.OrderBy(o => o.Abrv);
                case "VehicleMakeId Desc":
                    return Context.VehicleModels.OrderByDescending(o => o.VehicleMakeId);
                case "VehicleMakeId":
                    return Context.VehicleModels.OrderBy(o => o.VehicleMakeId);
                case "Name Desc":
                    return Context.VehicleModels.OrderByDescending(o => o.Name);
                default:
                    return Context.VehicleModels.OrderBy(o => o.Name);
            }
        }

        public async Task<IVehicleModel> UpdateVehicleModelAsync(IVehicleModel changedModel)
        {
            var model = Context.VehicleModels.Attach(Mapper.Map<Vehicle.DAL.Entities.VehicleModelEntity>(changedModel));
            model.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return changedModel;
        }

        public async Task<bool> ModelExists(int id)
        {
            return await Context.VehicleModels.AnyAsync(m => m.VehicleModelId == id);
        }
    }
}
