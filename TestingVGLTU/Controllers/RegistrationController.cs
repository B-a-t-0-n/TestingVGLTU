using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Interfaces.Repositories;
using TestingVGLTU.Interfaces.Services;
using TestingVGLTU.Models.Entity;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ILoginServices _userServices;

        public RegistrationController(ILoginServices userServices)
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
                    await _userServices.RegisterTeacher(model.Name, model.Surname, model.Patronymic, model.Login, model.Password);

                    return RedirectToAction("Login", "Authorization");
                }

                await _userServices.RegisterStudent(model.Name, model.Surname, model.Patronymic, model.Login, model.Password, (int)model.NumberRecordBook!, model!.Group!);

                return RedirectToAction("Login", "Authorization");
            }
            return View();
        }
    }
}
