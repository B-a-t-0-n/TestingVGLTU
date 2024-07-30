using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    [Authorize]
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
