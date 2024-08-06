using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingVGLTU.Data.Repositories;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers
{
    [Authorize(Policy = "Teacher")]
    public class CreateTestingController : Controller
    {
        private readonly ITestingService _testingService;
        private readonly ITeacherRepository _teacherRepository;

        public CreateTestingController(ITestingService testingService, ITeacherRepository teacherRepository)
        {
            _testingService = testingService;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuestion()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateTesting()
        {
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Teacher? teacher = await _teacherRepository.GetById(int.Parse(id!));

            ViewBag.Message = $"{teacher!.Surname} {teacher!.Name[0]}.{teacher!.Patronymic[0]}.";

            var typeTesting = await _testingService.GetTypeTestingAsync();
            var typeOutputOfResult = await _testingService.TypeOutputOfResultsAsync();

            CreateTestingViewModel model = new CreateTestingViewModel()
            {
                TypeTesting = typeTesting.Select(i => i.Name).ToList(),
                TypeOutputOfResult = typeOutputOfResult.Select(i => i.Name).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTesting(CreateTestingViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var typeTesting = await _testingService.GetTypeTestingAsync();
                var typeOutputOfResult = await _testingService.TypeOutputOfResultsAsync();

                model.TypeTesting = typeTesting.Select(i => i.Name).ToList();
                model.TypeOutputOfResult = typeOutputOfResult.Select(i => i.Name).ToList();

                return View(model);
            }

            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var testing = await _testingService.CreateAsync(model.Name!, model.Type!, model.OutputOfResult!, model.Attempts, model.Time, int.Parse(id!));

            return RedirectToAction("TestingEditor", "CreateTesting");
        }


        [HttpGet]
        public async Task<IActionResult> TestingEditor()
        {
            return View();
        }
    }
}
