using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Accounts.Application.Command.RegisterStudent;
using TestingVGLTU.Accounts.Application.Command.RegisterTeacher;
using TestingVGLTU.Core.Dtos;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers;

public class RegistrationController : Controller
{
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registration(
        [FromServices] RegisterStudentHandler registerStudentHandler,
        [FromServices] RegisterTeacherHandler registerTeacherHandler,
        RegistrationViewModel model)
    {
        if (ModelState.IsValid == false)
            return View();

        if (model.IsTeacher == true)
        {
            var command = new RegisterTeacherCommand(
                model.Login,
                model.Password,
                new FullNameDto
                (
                    model.Name,
                    model.Surname,
                    model.Patronymic
                ));

            var result = await registerTeacherHandler.Handle(command);
            if(result.IsFailure)
            {
                ModelState.AddModelError("", result.Error.First().Message);
                return View(model);
            }
        }
        else
        {
            var command = new RegisterStudentCommand(
                model.Login,
                model.Password,
                new FullNameDto
                (
                    model.Name,
                    model.Surname,
                    model.Patronymic
                ),
                new Guid("d8b660c3-f14e-43b5-8bbc-73dafef0bd3b"));

            var result = await registerStudentHandler.Handle(command);
            if (result.IsFailure)
            {
                ModelState.AddModelError("", result.Error.First().Message);
                return View(model);
            }

        }
        return RedirectToAction("Login", "Authorization");
    }
}
