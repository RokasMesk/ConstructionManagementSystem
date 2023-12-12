using Microsoft.AspNetCore.Mvc;
using Construction.Models;
using Construction.Models.ViewModels;
using Construction.DataAccess.Repository.IRepository;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ConstructionManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _db;

        public UserController(IUnitOfWork db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM information)
        {
            var userObject = _db.User.GetFirstOrDefault(u => u.Email == information.Email && u.Password == information.Password);
            if (userObject != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userObject.Email),
                // Add more claims as needed for authorization or additional user information
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Customize authentication cookie properties if necessary
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(claimsIdentity),
                                              authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password is wrong");
            return View();
        }

        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult SignUp(User user)
        //{
        //    _db.User.Add(user);
        //    _db.Save();
        //    return RedirectToAction("Login");
        //}

        public async Task<IActionResult> SiOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
