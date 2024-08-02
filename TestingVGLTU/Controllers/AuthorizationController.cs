using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserServices _userServices;

        public AuthorizationController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var user = await _userServices.Login(model.Login!, model.Password!);

                if (user == null)
                {
                    return View(model);
                }

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Login)
                };

                if (user is Teacher)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Teacher"));
                }

                if (user is Student)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Student"));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                ViewData["FullName"] = $"{user.Surname} {user.Name[0]}.{user.Patronymic[0]}.";

                return user is Teacher ? RedirectToAction("TestingEditor", "Cards") : RedirectToAction("HomeUser", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(ex);

                return View(model);
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authorization");
        }
    }
}
