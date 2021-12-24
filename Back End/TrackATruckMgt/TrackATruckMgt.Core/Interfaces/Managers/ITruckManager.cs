
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.DTOs;

namespace TrackATruckMgt.Core.Interfaces.Managers
{
    public interface ITruckManager
    {
        Task<TruckDto> Create(TruckDto truckDto);
        Task<TruckDto> GetById(long Id);
        Task<TruckDto[]> GetBySiteId(string SiteId);
        Task<TruckDto> GetAssetId(string AssetId);
        Task<TruckDto> GetRegistrationNumber(string RegistrationNumber);
        Task<TruckDto[]> GetAllTrucks();
    }
}
