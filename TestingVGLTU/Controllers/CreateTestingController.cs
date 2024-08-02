using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers
{
    [Authorize(Policy = "Teacher")]
    public class CreateTestingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> CreateQuestion()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTesting()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TestingEditor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTesting(CreateTestingViewModel model)
        {

            return View();
        }
    }
}
