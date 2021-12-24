using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Interfaces.Managers;
using TrackATruckMgt.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.Managers
{
    public class DriverManager : IDriverManager
    {
        private readonly IDriverRepository _driverRepository;
        public DriverManager(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;

        }
        public async Task<DriverDto> Create(DriverDto driverDto)
        {
         
            return await _driverRepository.Create(driverDto);
        }

        public async Task<DriverDto> Delete(long Id)
        {
            return await _driverRepository.Delete(Id);
        }

        public async Task<DriverDto> Edit(DriverDto driverDto)
        {
            return await _driverRepository.Edit(driverDto);
        }

        public async Task<DriverDto[]> GetAll()
        {
            return await  _driverRepository.GetAll();
        }

        public async  Task<DriverDto> GetByEmployeeNumber(string employeeNumber)
        {
            return await  _driverRepository.GetByEmployeeNumber(employeeNumber); 
        }

        public async Task<DriverDto> GetById(long Id)
        {
            return await _driverRepository.GetById(Id);
        }

        public async Task<DriverDto[]> GetBySiteId(string SiteId)
        {
            return await _driverRepository.GetBySiteId(SiteId);
        }
    }
}
