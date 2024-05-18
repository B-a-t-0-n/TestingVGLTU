using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    public class TableController : Controller
    {
        public IActionResult HistoryCreator()
        {
            return View();
        }

        public IActionResult HistoryUser()
        {
            return View();
        }
    }
}
