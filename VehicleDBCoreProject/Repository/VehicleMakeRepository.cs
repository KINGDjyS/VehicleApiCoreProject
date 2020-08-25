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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected IMapper Mapper;

        public VehicleMakeRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            UnitOfWork.CreateMakerRepository();
            Mapper = mapper;
        }
        public async Task<IVehicleMake> GetVehicleMakerAsync(int id)
        {
            return Mapper.Map<IVehicleMake>(await UnitOfWork.VehicleMakeRepository.GetById(id));
        }

        public async Task<List<IVehicleMake>> GetVehicleMakersAsync(Filtering filtering, Sorting sorting, Paging paging)
        {
            var make = await UnitOfWork.VehicleMakeRepository.Get();
            if (!String.IsNullOrEmpty(filtering.SearchName))
            {
                return new List<IVehicleMake>(Mapper.Map<List<IVehicleMake>>(await make.Where(f => f.Name.Contains(filtering.SearchName)).OrderBy(o => o.Name).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
            }
            return new List<IVehicleMake>(Mapper.Map<List<IVehicleMake>>(await SortVehicleMakers(make, sorting).Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync()));
        }

        private IQueryable<DAL.Entities.VehicleMakeEntity> SortVehicleMakers(IQueryable<Vehicle.DAL.Entities.VehicleMakeEntity> makers, Sorting sorting)
        {
            switch (sorting.SortBy)
            {
                case "Abrv Desc":
                    return makers.OrderByDescending(o => o.Abrv);
                case "Abrv":
                    return makers.OrderBy(o => o.Abrv);
                case "Name Desc":
                    return makers.OrderByDescending(o => o.Name);
                default:
                    return makers.OrderBy(o => o.Name);
            }
        }

        public async Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker)
        {
            await UnitOfWork.VehicleMakeRepository.Add(Mapper.Map<Vehicle.DAL.Entities.VehicleMakeEntity>(newMaker));
            await UnitOfWork.CommitAsync();
            return newMaker;
        }

        public async Task<IVehicleMake> UpdateVehicleMakerAsync(int id, IVehicleMake changedMaker)
        {
            var maker = await UnitOfWork.VehicleMakeRepository.Update(id, Mapper.Map<Vehicle.DAL.Entities.VehicleMakeEntity>(changedMaker));
            await UnitOfWork.CommitAsync();
            return Mapper.Map<IVehicleMake>(maker);
        }

        public async Task<int> DeleteVehicleMakerAsync(int id)
        {
            var maker = UnitOfWork.VehicleMakeRepository.GetById(id);
            await UnitOfWork.VehicleMakeRepository.Delete(maker.Result);
            await UnitOfWork.CommitAsync();
            return 1;
        }

        public async Task<bool> MakerExists(int id)
        {
            if (await UnitOfWork.VehicleMakeRepository.GetById(id) == null)
            {
                return false;
            }
            return true;
        }
    }
}
