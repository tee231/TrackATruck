using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackATruckMgt.Core.DTOs;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Core.Models;
using TrackATruckMgt.Core.Users;
using static TrackATruckMgt.Core.Utility.Constants;

namespace TrackATruckMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAuthController : ControllerBase
    {
        private readonly IUserRepository  _userRepo;

        public UsersAuthController(IUserRepository user)
        {
            _userRepo = user;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationDTo userRegistrationDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                userRegistrationDto.Username = userRegistrationDto.Username.ToLower();
                if (await _userRepo.UserExists(userRegistrationDto.Username))
                    return BadRequest("username is taken");

                var CreatingUser = new User
                {
                    UserName = userRegistrationDto.Username
                };
                var createdUser = await _userRepo.Register(CreatingUser, userRegistrationDto.Password);
               // return StatusCode(201);
                if (createdUser != null)
                {
                    // return Ok(CreatedDriver.DriverDto);
                    return Ok(new ResponseModel<object>
                    {
                        RequestSuccessful = true,
                        ResponseCode = ResponseCodes.Successful,
                        Message = $" Your Registration was Succesful.",
                        ResponseData = createdUser
                    });
                }
                return Ok();
            }

            catch (Exception)
            {
                // return StatusCode(StatusCodes.Status500InternalServerError, "could not create Driver"); this also works.

                return BadRequest(new ResponseModel<object>
                {
                    ResponseCode = ResponseCodes.Failed,
                    Message = "Failed. Your Registration Process failed"
                });
            }
        }
    }
}
