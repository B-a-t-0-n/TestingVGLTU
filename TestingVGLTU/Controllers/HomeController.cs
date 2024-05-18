using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomeUser()
        {
            return View();
        }
    }
}
