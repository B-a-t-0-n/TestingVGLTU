using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult HomeUser()
        {
            return View();
        }
    }
}
