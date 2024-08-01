using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Interfaces.Services;

namespace TestingVGLTU.Controllers
{
    
    public class CardsController : Controller
    {
        private readonly IUserServices _userServices;

        public CardsController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Authorize(Policy = "Teacher")]
        public IActionResult ActiveCreator()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Student")]
        public IActionResult ActiveUser()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Teacher")]
        public IActionResult HistoryTesting()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Student")]
        public IActionResult MailUser()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Teacher")]
        public IActionResult TestingEditor()
        {
            return View();
        }
    }
}
