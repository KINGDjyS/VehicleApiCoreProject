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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected VehicleDBContext Context { get; private set; }
        protected IMapper Mapper;

        public VehicleMakeRepository(VehicleDBContext context, IMapper mapper)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Makers DBContext");
            }
            Context = context;
            Mapper = mapper;
        }
        public async Task<IVehicleMake> GetVehicleMakerAsync(int id)
        {
            return Mapper.Map<IVehicleMake>(await Context.VehicleMakers.Where(m => m.VehicleMakeId == id).FirstOrDefaultAsync());
        }

        public async Task<List<IVehicleMake>> GetVehicleMakersAsync(Filtering filtering, Sorting sorting, Paging paging)
        {
            if (!String.IsNullOrEmpty(filtering.SearchName))
            {
                return new List<IVehicleMake>(Mapper.Map<List<IVehicleMake>>(await Context.VehicleMakers.Where(f => f.Name.Contains(filtering.SearchName)).OrderBy(o => o.Name).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
            }
            return new List<IVehicleMake>(Mapper.Map<List<IVehicleMake>>(await SortVehicleMakers(sorting).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
        }

        private IQueryable<DAL.Entities.VehicleMakeEntity> SortVehicleMakers(Sorting sorting)
        {
            switch (sorting.SortBy)
            {
                case "Abrv Desc":
                    return Context.VehicleMakers.OrderByDescending(o => o.Abrv);
                case "Abrv":
                    return Context.VehicleMakers.OrderBy(o => o.Abrv);
                case "Name Desc":
                    return Context.VehicleMakers.OrderByDescending(o => o.Name);
                default:
                    return Context.VehicleMakers.OrderBy(o => o.Name);
            }
        }

        public async Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker)
        {
            Context.VehicleMakers.Add(Mapper.Map<Vehicle.DAL.Entities.VehicleMakeEntity>(newMaker));
            await Context.SaveChangesAsync();
            return newMaker;
        }

        public async Task<IVehicleMake> UpdateVehicleMakerAsync(IVehicleMake changedMaker)
        {
            var make = Context.VehicleMakers.Attach(Mapper.Map<Vehicle.DAL.Entities.VehicleMakeEntity>(changedMaker));
            make.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return changedMaker;
        }

        public async Task<IVehicleMake> DeleteVehicleMakerAsync(int id)
        {
            Vehicle.DAL.Entities.VehicleMakeEntity make = Context.VehicleMakers.Find(id);
            Context.VehicleMakers.Remove(make);
            await Context.SaveChangesAsync();
            return Mapper.Map<IVehicleMake>(make);
        }

        public async Task<bool> MakerExists(int id)
        {
            return await Context.VehicleMakers.AnyAsync(m => m.VehicleMakeId == id);
        }
    }
}
