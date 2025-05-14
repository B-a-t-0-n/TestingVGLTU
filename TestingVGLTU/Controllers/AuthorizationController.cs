using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingVGLTU.Accounts.Application.Command.Login;
using TestingVGLTU.Accounts.Application.Queries.GerUserWithPagination;
using TestingVGLTU.Accounts.Domain.Entity;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers;

public class AuthorizationController : Controller
{

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(
        [FromServices] LoginHandler loginHandler,
        [FromServices] GetUserWithPaginationHandler getTypeTestingsWithPaginationHandler,
        LoginViewModel model,
        CancellationToken cancellationToken)
    {
        var command = new LoginCommand(model.Login, model.Password);

        var result = await loginHandler.Handle(command, cancellationToken);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.Error.First().Message);
            return View(model);
        }

        var user = result.Value;

        var fullName = $"{user.FullName.Surname} {user.FullName.FirstName[0]}.{user.FullName.Patronymic![0]}.";

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.Value.ToString()),
            new Claim(ClaimTypes.Name, fullName)
        };

        if (user.Teacher is not null)
        {
            claims.Add(new Claim(ClaimTypes.Role, nameof(Teacher)));
        }

        if (user.Student is not null)
        {
            claims.Add(new Claim(ClaimTypes.Role, nameof(Student)));
        }

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return user is Teacher ? RedirectToAction("TestingEditor", "Cards") : RedirectToAction("HomeUser", "Home");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Authorization");
    }
}
