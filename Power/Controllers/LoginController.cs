using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Power.BO;
using Power.Models;
using System;
using System.Threading.Tasks;

namespace Power.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception("Invalid login attempt");
                }
            }
            return View(model);
        }
    }
}