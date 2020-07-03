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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected VehicleDBContext Context { get; private set; }

        public VehicleMakeRepository(VehicleDBContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Makers DBContext");
            }
            Context = context;
        }
        public async Task<VehicleMakeEntity> GetVehicleMakerAsync(int id)
        {
            return await Context.VehicleMakers.Where(m => m.VehicleMakeId == id).FirstOrDefaultAsync();
        }

        public async Task<List<VehicleMakeEntity>> GetVehicleMakersAsync()
        {
            return await Context.VehicleMakers.OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<VehicleMakeEntity> AddVehicleMakerAsync(VehicleMakeEntity newMaker)
        {
            Context.VehicleMakers.Add(newMaker);
            await Context.SaveChangesAsync();
            return newMaker;
        }

        public async Task<VehicleMakeEntity> UpdateVehicleMakerAsync(VehicleMakeEntity changedMaker)
        {
            var make = Context.VehicleMakers.Attach(changedMaker);
            make.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return changedMaker;
        }

        public async Task<VehicleMakeEntity> DeleteVehicleMakerAsync(int id)
        {
            VehicleMakeEntity make = Context.VehicleMakers.Find(id);
            Context.VehicleMakers.Remove(make);
            await Context.SaveChangesAsync();
            return make;
        }

        public async Task<bool> MakerExists(int id)
        {
            return await Context.VehicleMakers.AnyAsync(m => m.VehicleMakeId == id);
        }
    }
}
