using HotelBookingSystemApplication.Interfaces;
using HotelBookingSystemApplication.Models.DTOs;
using HotelBookingSystemApplication.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystemApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpPost("Register")]
        
        public ActionResult Register(UserRegisterDTO register)
        {
            var user = userService.Register(register);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest("Email already exist");
        }
        [HttpPost("Login")]
        public ActionResult Login(UserLoginDTO login)
        {
            var user = userService.Login(login);
            if(user != null)
            {
                return Ok(user);
            }
            return BadRequest("Invalid Email or Password");
        }
    }
}
