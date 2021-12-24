using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Core.Utility;
using TrackATruckMgt.Data;
using TrackATruckMgt.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace TrackATruckMgt.Infrstructure.Implementations.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly APPContext _appContext;
        private readonly IMapper _mapper;
        public DriverRepository(APPContext appContext, IMapper mapper)
        {
                 _appContext = appContext;
                  _mapper = mapper;

        }
      
    
        public async Task<DriverDto> Create(DriverDto driverDto)
        {

           _appContext.Set<DriverDto>().ToList();
            DriverDto fresh = new DriverDto()
            {
                
                Name = driverDto.Name,
                EmployeeNumber = driverDto.EmployeeNumber,
                SiteId = driverDto.SiteId,
                DriverId = driverDto.DriverId,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = driverDto.CreatedBy,
                UpdatedAt = driverDto.UpdatedAt,
                UpdatedBy = driverDto.UpdatedBy,
                IsActive = driverDto.IsActive
            };
             _appContext.Add(fresh);
             await _appContext.SaveChangesAsync();

            return fresh;

        }
        public async  Task<DriverDto[]> GetAll()
        {
            var e =  _appContext.Set<DriverDto>().ToList();

            if (e.Count <= 0)
                return Array.Empty<DriverDto>();

            var result = e.Select(r => new DriverDto().Assign(r)).ToArray();
            return result;
        }

        public async  Task<DriverDto> GetByEmployeeNumber(string employeeNumber)
        {
            var findentity = await _appContext.Drivers.FirstOrDefaultAsync(x => x.EmployeeNumber == employeeNumber);
            if (findentity == null)
                return null;
            return new DriverDto().Assign(findentity);
        }

        public async  Task<DriverDto> GetById(long Id)
        {
            var findentity = await _appContext.Drivers.FirstOrDefaultAsync(x => x.Id == Id);
            if (findentity == null)
                return null;
            return new DriverDto().Assign(findentity);
        }

        public async Task<DriverDto[]> GetBySiteId(string SiteId)
        {
            var findentity = await _appContext.Drivers.Where(x => x.SiteId == SiteId).ToArrayAsync();
            if (findentity.Length <= 0)
                return Array.Empty<DriverDto>();

            var result = findentity.Select(r => new DriverDto().Assign(r)).ToArray();
            return result;
        }

        public async Task<DriverDto> Delete(long Id)
        {
           

            var ToDelete = await _appContext.Drivers
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (ToDelete != null)
            {
                _appContext.Drivers.Remove(ToDelete);
                await _appContext.SaveChangesAsync();
            }
            return null;
        }

        //public async Task<DriverDto> Edit(DriverDto driverDto)
        //{

        //    _appContext.Entry(driverDto).State = EntityState.Modified;
        //    await _appContext.SaveChangesAsync();


        //    return driverDto;
        //}


        public async Task<DriverDto> Edit(DriverDto driverDto)
        {
            DriverDto EditDriver = await _appContext.Drivers
                .FirstOrDefaultAsync(e => e.DriverId == driverDto.DriverId);
                      
            if (EditDriver != null)
            {
                EditDriver.Name = driverDto.Name;
                EditDriver.EmployeeNumber = driverDto.EmployeeNumber;
                EditDriver.SiteId = driverDto.SiteId;
                EditDriver.DriverId = driverDto.DriverId;
                EditDriver.UpdatedAt = DateTime.Now;
                EditDriver.CreatedBy = driverDto.CreatedBy;
                EditDriver.UpdatedAt = DateTime.Now;
                EditDriver.UpdatedBy = driverDto.UpdatedBy;
               
                EditDriver.IsActive = driverDto.IsActive;
               
                await _appContext.SaveChangesAsync();

                    return EditDriver;
            }
            return null;
        }

       
    }
}
