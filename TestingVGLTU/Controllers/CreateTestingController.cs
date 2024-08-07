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
        private readonly IGroupRepository _groupRepository;

        public CreateTestingController(ITestingService testingService, ITeacherRepository teacherRepository, IGroupRepository groupRepository)
        {
            _testingService = testingService;
            _teacherRepository = teacherRepository;
            _groupRepository = groupRepository;
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

            return RedirectToActionPermanent("TestingEditor", "CreateTesting", new { id = testing!.Id });
        }


        [HttpGet]
        public async Task<IActionResult> TestingEditor(int id)
        {
            var testing = await _testingService.GetByTestingIdFullData(id);

            var typeTesting = await _testingService.GetTypeTestingAsync();
            var typeOutputOfResult = await _testingService.TypeOutputOfResultsAsync();
            var groups = await _groupRepository.Get();

            var model = new TestingEditorViewModel()
            {
                Id = id,
                Name = testing!.Name,
                Attempts = testing!.Attempts,
                Time = testing.Time.Minute + testing.Time.Hour * 60,
                OutputOfResult = testing!.TypeOutputOfResult.Name,
                Type = testing!.TypeTesting.Name,
                Groups = groups,
                Question = testing!.Questions.ToList(),
                TypeOutputOfResult = typeOutputOfResult.Select(i => i.Name).ToList(),
                TypeTesting = typeTesting.Select(i => i.Name).ToList(),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateQuestion(int id)
        {

            return View();
        }
    }
}
