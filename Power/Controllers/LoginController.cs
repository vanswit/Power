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
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            var model = new LoginModel() { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                if (result.Succeeded)
                {
                    if (returnUrl != null)
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home", null);
                }
                else
                {
                    throw new Exception("Invalid login attempt");
                }
            }
            return View(model);
        }

        [Route("/register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Home", "Index");
                }
            }
            return View(model);
        }

        [Route("/logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("loggedout","login");
        }

        [Route("/loggedout")]
        public IActionResult LoggedOut()
        {
            return View();
        }
    }
}