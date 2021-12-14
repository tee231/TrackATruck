using System.Threading.Tasks;
using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Models;


namespace TrackATruckMgt.Core.Interfaces.Repositories
{
    public interface IPositionRepository
    {

        Task<PositionDto> Create(PositionDto position);
       
        Task<PositionDto[]> GetByAssetId(string AssetId);
        Task<PositionDto[]> GetAllPositions();
        Task<PositionDto> GetByAssetIdAndDriverId(string AssetId, string DriverId);
        Task<CurrentLocationDto> GetCurrentLocation(string AssetId, string DriverId);
    }
}
