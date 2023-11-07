using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Interfaces;
using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public ActionResult Register(UserDTO viewModel)
        {
            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if(user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp) {
                message = "Duplicate username";
            }
            catch(Exception) { 
                
            }
            return BadRequest(message);
        }
        [HttpGet]
        public ActionResult Login(UserDTO viewModel) {
            string message = "Invalid username or password";
            var user = _userService.Login(viewModel);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(message);
        }
    }
}
