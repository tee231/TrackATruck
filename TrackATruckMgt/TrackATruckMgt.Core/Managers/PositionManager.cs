using TrackATruckMgt.Core.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Interfaces.Managers;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Core.Models;

namespace TrackATruckMgt.Core.Managers
{
    public  class PositionManager: IPositionManager
    {
        private readonly IPositionRepository _positionRepository;
        public PositionManager(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<PositionDto[]> GetAllPositions()
        {
            return await _positionRepository.GetAllPositions();
        }

        public async Task<PositionDto[]> GetByAssetId(string AssetId)
        {
            return await _positionRepository.GetByAssetId(AssetId);
        }

        public async Task<PositionDto> GetByAssetIdAndDriverId(string AssetId, string DriverId)
        {
            return await _positionRepository.GetByAssetIdAndDriverId(AssetId, DriverId);
        }

        public async  Task<CurrentLocationDto> GetCurrentLocation(string AssetId, string DriverId)
        {
            return await _positionRepository.GetCurrentLocation(AssetId, DriverId);
        }
    }
}
