using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Models;
using TrackATruckMgt.Core.Utility;
using TrackATruckMgt.Data;
using TrackATruckMgt.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Interfaces.Repositories;

namespace TrackATruckMgt.Infrstructure.Implementations.Repositories
{
    public class PositionRepository: IPositionRepository
    {
        private readonly APPContext _appContext;
        public PositionRepository(APPContext aPPContext)
        {
            _appContext = aPPContext;
        }

        public async Task<PositionDto[]> GetAllPositions()
        {
            var e = _appContext.Set<Position>().ToList();

            if (e.Count <= 0)
                return Array.Empty<PositionDto>();

            var result = e.Select(r => new PositionDto().Assign(r)).ToArray();
            return result;
        }
        public async Task<PositionDto> GetByAssetIdAndDriverId(string AssetId, string DriverId)
        {
            var findentity = await _appContext.Positions.FirstOrDefaultAsync(x => x.AssetId == AssetId && x.DriverId == DriverId);
            if (findentity == null)
                return null;
            return new PositionDto().Assign(findentity);

        }

        public async Task<CurrentLocationDto> GetCurrentLocation(string AssetId, string DriverId)
        {

            var q = await (from position in _appContext.Set<Position>()
                           join truckInfo in _appContext.Set<Truck>()
                           on position.AssetId equals truckInfo.AssetId
                           where position.AssetId == AssetId && position.DriverId == DriverId
                           select new CurrentLocationDto
                           {
                               Address = truckInfo.CurrentAddress,
                               Longitude = position.Longitude,
                               Latitude = position.Latitude,
                               LastPositionTimestamp = truckInfo.LastPositionTimestamp


                           }).FirstOrDefaultAsync();

            return q;



        }
        public Task<PositionDto[]> GetByAssetId(string AssetId)
        {
            throw new NotImplementedException();
        }
    }
}
