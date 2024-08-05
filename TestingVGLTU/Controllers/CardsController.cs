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
        private readonly ITeacherRepository _teacherRepository;

        public CardsController(ITeacherRepository teacherRepository)
        {
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

            return View(teacher!.Testings.ToList());
        }
    }
}
