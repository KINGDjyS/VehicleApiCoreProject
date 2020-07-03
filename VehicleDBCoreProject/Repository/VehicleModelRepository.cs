using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Common;

namespace Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        protected VehicleDBContext Context { get; private set; }

        public VehicleModelRepository(VehicleDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Models DBContext");
            }
            Context = context;
        }
        public async Task<VehicleModelEntity> AddVehicleModelAsync(VehicleModelEntity newModel)
        {
            Context.VehicleModels.Add(newModel);
            await Context.SaveChangesAsync();
            return newModel;
        }

        public async Task<VehicleModelEntity> DeleteVehicleModelAsync(int id)
        {
            VehicleModelEntity model = Context.VehicleModels.Find(id);
            Context.VehicleModels.Remove(model);
            await Context.SaveChangesAsync();
            return model;
        }

        public async Task<VehicleModelEntity> GetVehicleModelAsync(int id)
        {
            return await Context.VehicleModels.Where(m => m.VehicleModelId == id).FirstOrDefaultAsync();
        }

        public async Task<List<VehicleModelEntity>> GetVehicleModelsAsync()
        {
            return await Context.VehicleModels.OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<VehicleModelEntity> UpdateVehicleModelAsync(VehicleModelEntity changedModel)
        {
            var model = Context.VehicleModels.Attach(changedModel);
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
