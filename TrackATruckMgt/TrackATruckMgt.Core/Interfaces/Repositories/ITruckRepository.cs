using TrackATruckMgt.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.Interfaces.Repositories
{
    public interface ITruckRepository
    {
        Task<TruckDto> Create(TruckDto truckDto);
        Task<TruckDto> GetById(long Id  );
        Task<TruckDto[]> GetBySiteId(string SiteId);
        Task<TruckDto> GetAssetId(string AssetId);
        Task<TruckDto> GetRegistrationNumber(string RegistrationNumber);
        Task<TruckDto[]> GetAllTrucks();
    }
}
