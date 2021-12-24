using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Interfaces.Managers;

namespace TrackATruckMgt.Core.Managers
{
    public class TruckManager : ITruckManager
    {
        private readonly ITruckRepository _truckRepository;
        public TruckManager(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }
        public async  Task<TruckDto> Create(TruckDto truckDto)
        {
            return await _truckRepository.Create(truckDto);
        }

        public  async Task<TruckDto[]> GetAllTrucks()
        {
            return await _truckRepository.GetAllTrucks();
        }

        public async Task<TruckDto> GetAssetId(string AssetId)
        {
            return await _truckRepository.GetAssetId(AssetId);
        }

        public async Task<TruckDto> GetById(long Id)
        {
            return await _truckRepository.GetById(Id);
        }

        public async Task<TruckDto[]> GetBySiteId(string SiteId)
        {
            return await _truckRepository.GetBySiteId(SiteId);
        }

        public async Task<TruckDto> GetRegistrationNumber(string RegistrationNumber)
        {
            return await _truckRepository.GetRegistrationNumber(RegistrationNumber);
        }
    }
}
