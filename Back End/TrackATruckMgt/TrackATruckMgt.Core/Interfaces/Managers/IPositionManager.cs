

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Models;

namespace TrackATruckMgt.Core.Interfaces.Managers
{
    public interface IPositionManager
    {

        Task<PositionDto[]> GetByAssetId(string AssetId);
        Task<PositionDto[]> GetAllPositions();
        Task<PositionDto> GetByAssetIdAndDriverId(string AssetId, string DriverId);
        Task<CurrentLocationDto> GetCurrentLocation(string AssetId, string DriverId);
    }
}
