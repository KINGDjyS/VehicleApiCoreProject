using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;

namespace Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository Repository { get; private set; }
        protected IMapper Mapper;
        public VehicleMakeService(IVehicleMakeRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        public async Task<IVehicleMake> GetVehicleMakerAsync(int id)
        {
            return Mapper.Map<IVehicleMake>(await Repository.GetVehicleMakerAsync(id));
        }

        public async Task<List<IVehicleMake>> GetVehicleMakersAsync()
        {
            return new List<IVehicleMake>(Mapper.Map<List<IVehicleMake>>(await Repository.GetVehicleMakersAsync()));
        }

        public async Task<IVehicleMake> AddVehicleMakerAsync(IVehicleMake newMaker)
        {
            return Mapper.Map<IVehicleMake>(await Repository.AddVehicleMakerAsync(Mapper.Map<DAL.Entities.VehicleMakeEntity>(newMaker)));
        }

        public async Task<IVehicleMake> UpdateVehicleMakerAsync(IVehicleMake changedMaker)
        {
            return Mapper.Map<IVehicleMake>(await Repository.UpdateVehicleMakerAsync(Mapper.Map<DAL.Entities.VehicleMakeEntity>(changedMaker)));
        }

        public async Task<IVehicleMake> DeleteVehicleMakerAsync(int id)
        {
            return Mapper.Map<IVehicleMake>(await Repository.DeleteVehicleMakerAsync(id));
        }

        public async Task<bool> MakerExists(int id)
        {
            return await Repository.MakerExists(id);
        }
    }
}
