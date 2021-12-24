using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Core.Utility;
using TrackATruckMgt.Data;
using TrackATruckMgt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Infrstructure.Implementations.Repositories
{
    public class TruckRepository: ITruckRepository
    {
        private readonly APPContext _appContext;
        public TruckRepository(APPContext aPPContext)
        {
            _appContext = aPPContext;
        }

        public Task<TruckDto> Create(TruckDto truckDto)
        {
            throw new NotImplementedException();
        }

        public async Task<TruckDto[]> GetAllTrucks()
        {
            var e = _appContext.Set<Truck>().ToList();

            if (e.Count <= 0)
                return Array.Empty<TruckDto>();

            var result = e.Select(r => new TruckDto().Assign(r)).ToArray();
            return result;
        }

        public async Task<TruckDto> GetAssetId(string AssetId)
        {
            var findentity = await _appContext.Trucks.FirstOrDefaultAsync(x => x.AssetId == AssetId);
            if (findentity == null)
                return null;
            return new TruckDto().Assign(findentity);
        }

        public async Task<TruckDto> GetById(long Id)
        {
            var findentity = await _appContext.Trucks.FirstOrDefaultAsync(x => x.Id == Id);
            if (findentity == null)
                return null;
            return new TruckDto().Assign(findentity);
        }

        public async Task<TruckDto[]> GetBySiteId(string SiteId)
        {
            var findentity = await _appContext.Trucks.Where(x => x.SiteId == SiteId).ToArrayAsync();
            if (findentity.Length <= 0)
                return Array.Empty<TruckDto>();

            var result = findentity.Select(r => new TruckDto().Assign(r)).ToArray();
            return result;
        }

        public async  Task<TruckDto> GetRegistrationNumber(string RegistrationNumber)
        {
            var findentity = await _appContext.Trucks.FirstOrDefaultAsync(x => x.RegistrationNumber == RegistrationNumber);
            if (findentity == null)
                return null;
            return new TruckDto().Assign(findentity);
        }
    }
}
