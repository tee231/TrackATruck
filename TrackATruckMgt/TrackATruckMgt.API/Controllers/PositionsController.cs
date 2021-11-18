
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TrackATruckMgt.Core.Interfaces.Managers;
using TrackATruckMgt.Core.Models;
using static TrackATruckMgt.Core.Utility.Constants;

namespace TrackATruckMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionManager _positionsManager;
        public PositionsController(IPositionManager positionManager)
        {
            _positionsManager = positionManager;

        }
        [HttpGet("GetAllPositions")]
        public async Task<IActionResult> GetAllDrivers()
        {

            var result = await _positionsManager.GetAllPositions();
            if (result != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Position records retrieved Succesfully.",
                    ResponseData = result
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }



        [HttpGet("CurrentPositionByDriver/{AssetId}/{DriverId}")]
        public async Task<IActionResult> CurrentPositionByDriver(string AssetId, string DriverId)
        {
            if (string.IsNullOrEmpty(AssetId) || string.IsNullOrEmpty(DriverId))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "SiteId is required"));

            var position = await _positionsManager.GetCurrentLocation(AssetId, DriverId);
            if (position != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Position record retrieved succesfully.",
                    ResponseData = position
                });
            }

            else return BadRequest(new ResponseModel<object>
            {
                ResponseCode = ResponseCodes.Failed,
                Message = "Failed. Please try again or contact your administrator"
            });

        }

        [HttpGet("PositionByDriverAndTruckId/{AssetId}/{DriverId}")]
        public async Task<IActionResult> PositionByDriverAndTruckId(string AssetId, string DriverId)
        {
            if (string.IsNullOrEmpty(AssetId) || string.IsNullOrEmpty(DriverId))
                return BadRequest(ResponseObject<string>.Failed(string.Empty, "SiteId is required"));

            var position = await _positionsManager.GetByAssetIdAndDriverId(AssetId, DriverId);
            if (position != null)
            {
                return Ok(new ResponseModel<object>
                {
                    RequestSuccessful = true,
                    ResponseCode = ResponseCodes.Successful,
                    Message = $"Position record retrieved succesfully.",
                    ResponseData = position
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
