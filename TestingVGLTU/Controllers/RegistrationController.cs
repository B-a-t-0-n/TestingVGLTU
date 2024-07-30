using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models;
using TestingVGLTU.Services;
using TestingVGLTU.ViewModel;

namespace TestingVGLTU.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserServices _userServices;

        public RegistrationController(IUserServices userServices)
        {
            _userServices = userServices;
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

                var student = new Student()
                {
                    Name = model.Name!,
                    Surname = model.Surname!,
                    Patronymic = model.Patronymic!,
                    Password = model.Password!,
                    Login = model.Login!,
                    NumberRecordBook = (int)model.NumberRecordBook!
                };

                await _userServices.RegisterStudent(student);

                return RedirectToAction("Login", "Authorization");
            }
            return View();
        }
    }
}
