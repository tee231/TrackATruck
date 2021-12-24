
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TrackATruckMgt.Core.Interfaces.Managers;
using static TrackATruckMgt.Core.Utility.Constants;
using TrackATruckMgt.Core.Models;

namespace TrackATruckMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly ITruckManager _truckManager;
        public TrucksController(ITruckManager truckManager)
        {
            _truckManager = truckManager;
        }
        [HttpGet("GetAllTrucks")]
        public async Task<IActionResult> GetAllDrivers()
        {

            var result = await _truckManager.GetAllTrucks();
            if (result != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Trucks records retrieved Succesfully.",
                    ResponseData = result
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }

        [HttpGet("GetTruckByAssetId/{AssetId}")]
        public async Task<IActionResult> GetTruckByAssetId(string AssetId)
        {
            if (string.IsNullOrEmpty(AssetId))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "AssetId is required"));

            var truck = await _truckManager.GetAssetId(AssetId);
            if (truck != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Truck Record retrieved succesfully.",
                    ResponseData = truck
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }

        [HttpGet("GetTruckByRegNumber/{RegNo}")]
        public async Task<IActionResult> GetTruckByRegNumber(string RegNo)
        {
            if (string.IsNullOrEmpty(RegNo))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "AssetId is required"));

            var truck = await _truckManager.GetRegistrationNumber(RegNo);
            if (truck != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Truck Record retrieved succesfully.",
                    ResponseData = truck
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }

        [HttpGet("GetTruckBySite/{SiteId}")]
        public async Task<IActionResult> GetTruckBySite(string SiteId)
        {
            if (string.IsNullOrEmpty(SiteId))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "SiteId is required"));

            var categories = await _truckManager.GetBySiteId(SiteId);
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

    }
}
