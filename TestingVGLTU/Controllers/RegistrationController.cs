using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers;

public class RegistrationController : Controller
{
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(RegistrationViewModel model)
    {
        return View();
    }
}
