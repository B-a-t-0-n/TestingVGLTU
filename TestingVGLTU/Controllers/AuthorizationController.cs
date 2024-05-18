using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
