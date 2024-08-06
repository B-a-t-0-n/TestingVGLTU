using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;

namespace TestingVGLTU.Controllers
{
    
    public class CardsController : Controller
    {
        private readonly ITestingService _testingService;
        private readonly ITeacherRepository _teacherRepository;

        public CardsController(ITestingService testingService, ITeacherRepository teacherRepository)
        {
            _testingService = testingService;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        [Authorize(Policy = "Teacher")]
        public async Task<IActionResult> ActiveCreator()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Student")]
        public async Task<IActionResult> ActiveUser()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Teacher")]
        public async Task<IActionResult> HistoryTesting()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Student")]
        public async Task<IActionResult> MailUser()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "Teacher")]
        public async Task<IActionResult> TestingEditor()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Teacher? teacher = await _teacherRepository.GetById(int.Parse(id!));

            ViewBag.Message = $"{teacher!.Surname} {teacher!.Name[0]}.{teacher!.Patronymic[0]}.";

            var testing = await _testingService.GetByTeacherId(teacher.Id);

            return View(testing);
        }

        [HttpPost]
        [Authorize(Policy = "Teacher")]
        public async Task<IActionResult> DeleteTesting(int testingId)
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Teacher? teacher = await _teacherRepository.GetById(int.Parse(id!));

            ViewBag.Message = $"{teacher!.Surname} {teacher!.Name[0]}.{teacher!.Patronymic[0]}.";

            await _testingService.Delete(testingId);

            var testing = await _testingService.GetByTeacherId(teacher.Id);

            return RedirectToAction("TestingEditor");
        }
    }
}
