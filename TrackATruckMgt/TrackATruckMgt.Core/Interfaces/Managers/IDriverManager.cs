using TrackATruckMgt.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackATruckMgt.Core.Interfaces.Managers
{
    public interface  IDriverManager
    {
        Task<DriverDto> Create(DriverDto driverDto);
        Task<DriverDto> GetById(long Id);
        Task<DriverDto> GetByEmployeeNumber(string employeeNumber);
        Task<DriverDto[]> GetBySiteId(string SiteId);
        Task<DriverDto[]> GetAll();
        Task<DriverDto> Delete(long Id);
        Task<DriverDto> Edit(DriverDto driverDto);
    }
}
