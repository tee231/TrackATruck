using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Interfaces.Managers;
using TrackATruckMgt.Core.Models;
using static TrackATruckMgt.Core.Utility.Constants;

namespace TrackATruckMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {

        private readonly IDriverManager _driverManager;
        private readonly IMapper _mapper;
        public DriversController(IDriverManager driverManager, IMapper mapper)
        {
            _driverManager = driverManager;
            _mapper = mapper;
        }

        [HttpPost("CreateDriver")]
        public async Task<IActionResult> CreateDriver(DriverDto driverDto)
        {
            try
            {

                if (driverDto == null)

                    return BadRequest();

                var CreatedDriver = await _driverManager.Create(driverDto);
                if (CreatedDriver != null)
                {
                    // return Ok(CreatedDriver.DriverDto);
                    return Ok(new ResponseModel<object>
                    {
                        RequestSuccessful = true,
                        ResponseCode = ResponseCodes.Successful,
                        Message = $"Drivers records was succesfully Created.",
                        ResponseData = CreatedDriver
                    });
                }
                return Ok();

                //return CreatedAtAction(nameof(CreateDriver), new
                //{
                //    id = CreatedDriver.DriverId,
                //    //Name = CreatedDriverr.Name,
                //    //SiteId = CreatedDriverr.SiteId,
                //    //EmployeeNumber = CreatedDriverr.EmployeeNumber
                //}, CreatedDriver);


            }


            catch (Exception)
            {
                // return StatusCode(StatusCodes.Status500InternalServerError, "could not create Driver"); this also works.

                return BadRequest(new ResponseModel<object>
                {
                    ResponseCode = ResponseCodes.Failed,
                    Message = "Failed. You Were unable to create Driver"
                });
            }


        }


        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> GetAllDrivers()
        {

            var result = await _driverManager.GetAll();
            if (result != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Drivers records retrieved Succesfully.",
                    ResponseData = result
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }

        [HttpGet("GetByEmpNumber/{EmpNumber}")]
        public async Task<IActionResult> GetByEmpNumber(string EmpNumber)
        {
            if (string.IsNullOrEmpty(EmpNumber))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "Employee Number is required"));

            var truck = await _driverManager.GetByEmployeeNumber(EmpNumber);
            if (truck != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Employee Record retrieved succesfully.",
                    ResponseData = truck
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }
        [HttpGet("GetBySite/{SiteId}")]
        public async Task<IActionResult> GetBySite(string SiteId)
        {
            if (string.IsNullOrEmpty(SiteId))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "SiteId is required"));

            var categories = await _driverManager.GetBySiteId(SiteId);
            if (categories.Length > 0)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Truck records retrieved succesfully.",
                    ResponseData = categories
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }
        // PUT / Drivers/ {DriverId}
        [HttpPut("{DriverId}")]
        public async Task<IActionResult> EditDriver(DriverDto driverDto)
         
        {
            if (driverDto != null)
            {
                var driver = await _driverManager.Edit(driverDto);
               
                if (driver != null)
                {
                    return Ok(new ResponseModel<object>
                    {
                        RequestSuccessful = true,
                        ResponseCode = ResponseCodes.Successful,
                        Message = $"Employee Record succesfully Updated.",
                        ResponseData = driver
                    });
                }


            }
            return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Driver Could not be Updated"
            });

           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var deleteItem = await _driverManager.Delete(id);
            if (deleteItem != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Employee Record succesfully Deleted.",
                    ResponseData = deleteItem
                });
            }
            return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Driver Could not be Deleted"
            });
        }
    }
}