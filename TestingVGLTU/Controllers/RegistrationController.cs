using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly Interfaces.Services.IUserServices _userServices;
        private readonly IGroupRepository _groupRepository;

        public RegistrationController(Interfaces.Services.IUserServices userServices, IGroupRepository groupRepository)
        {
            _userServices = userServices;
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.IsTeacher)
                {
                    var teacher = new Teacher()
                    {
                        Name = model.Name!,
                        Surname = model.Surname!,
                        Patronymic = model.Patronymic!,
                        Password = model.Password!,
                        Login = model.Login!
                    };

                    await _userServices.RegisterTeacher(teacher);

                    return RedirectToAction("Login", "Authorization");
                }

                var group = await _groupRepository.GetByName(model.Group!);

                var student = new Student()
                {
                    Name = model.Name!,
                    Surname = model.Surname!,
                    Patronymic = model.Patronymic!,
                    Password = model.Password!,
                    Login = model.Login!,
                    NumberRecordBook = (int)model.NumberRecordBook!,
                    GroupId = group!.Id
                };

                await _userServices.RegisterStudent(student);

                return RedirectToAction("Login", "Authorization");
            }
            return View();
        }
    }
}
