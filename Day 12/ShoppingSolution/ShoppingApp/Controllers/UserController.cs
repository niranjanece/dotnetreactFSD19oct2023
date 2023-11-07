using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Interfaces;
using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel viewModel)
        {
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DbUpdateException exp)
            {
                ViewBag.Message = "User name already exits";
            }
            catch (Exception)
            {
                ViewBag.Message = "Invalid data. Coudld not register";
                throw;
            }
            //ViewData["Message"] = "Invalid data. Coudld not register";

            return View();
        }
        public IActionResult Login()
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Login(UserDTO user) {
            var result = _userService.Login(user);
            if(result != null)
            {
                TempData.Add("username",user.Username);
                return RedirectToAction("Index", "Home");
            }
            //used to show error message
            // ModelState.AddModelError(string.Empty, "Invalid user name or password");

            //alternate method to show error if we use this method need to add something in views
            ViewData["Message"] = "Invalid username or password";
            //alternate met
            return View();
        }
    }
}
