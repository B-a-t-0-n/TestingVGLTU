using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Create;
using TestingVGLTU.LayoutTestings.Application.Queries.LayoutTestings.GetLayoutTestingsById;
using TestingVGLTU.LayoutTestings.Application.Queries.Questions.GetQuestionsWithPaginationFiltration;
using TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingWithPagination;
using TestingVGLTU.LayoutTestings.Domain.ValueObjects;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers;

[Authorize(Policy = "Teacher")]
public class CreateTestingController : Controller
{

    [HttpGet]
    public async Task<IActionResult> CreateTesting(
        [FromServices] GetTypeTestingsAllHandler typeTestingHandler,
        CancellationToken cancellationToken)
    {
        var typeTestings = await typeTestingHandler.Handle(
            new GetTypeTestingsAllQuery(
                null,
                null),
            cancellationToken);

        var typeOutPut = TypeOutPut.All.Select(t => t.Value).ToList();

        var model = new CreateTestingViewModel
        {
            TypeTestings = typeTestings,
            TypesOutputOfResult = typeOutPut,
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTesting(
        [FromServices] CreateLayoutTestingHandler handler,
        CreateTestingViewModel model,
        CancellationToken cancellationToken)
    {
        if (ModelState.IsValid == false)
            return RedirectToActionPermanent("CreateTesting", "CreateTesting");

        var hours = model.Time / 60;
        var minutes = model.Time % 60;

        var id = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

        var time = new DateTime(1, 1, 1, hours, minutes, 0, DateTimeKind.Utc);

        var result = await handler.Handle(
            new CreateLayoutTestingCommand(
                model.Name,
                model.Attempts,
                new Guid(model.TypeTestingId),
                time,
                id,
                model.OutputOfResult),
            cancellationToken);
        if (result.IsFailure)
        {
            ModelState.AddModelError("", result.Error.First().Message);
            return RedirectToActionPermanent("CreateTesting", "CreateTesting");
        }

        return RedirectToActionPermanent("TestingEditor", "CreateTesting", new { layoutTestingId = result.Value.ToString() });
    }

    [HttpGet]
    public async Task<IActionResult> TestingEditor(
        [FromServices] GetTypeTestingsAllHandler typeTestingHandler,
        [FromServices] GetLayoutTestingsByIdHandler layoutTestingsHandler,
        [FromServices] GetQuestionsWithPaginationFiltrationHandler questionsHandler,
        Guid layoutTestingId,
        CancellationToken cancellationToken)
    {
        var layoutTesting = await layoutTestingsHandler.Handle(
            new GetLayoutTestingsByIdQuery(layoutTestingId),
            cancellationToken);
        if (layoutTesting is null)
        {
            throw new ArgumentNullException(nameof(layoutTesting));
        }

        var questions = await questionsHandler.Handle(
           new GetQuestionsWithPaginationFiltrationQuery(
               layoutTestingId,
               null,
               null,
               null,
               null,
               null,
               1,
               100),
           cancellationToken);

        var typeTestings = await typeTestingHandler.Handle(
            new GetTypeTestingsAllQuery(
                null,
                null),
            cancellationToken);

        var typeOutPut = TypeOutPut.All.Select(t => t.Value).ToList();

        var model = new TestingEditorViewModel
        {
            CreateTestingViewModel = new CreateTestingViewModel
            {
                Name = layoutTesting.Title,
                Attempts = layoutTesting.Attemps,
                TypeTestingId = layoutTesting.TypeTestingId.ToString(),
                Time = layoutTesting.Time.Minute + layoutTesting.Time.Hour * 60,
                OutputOfResult = layoutTesting.TypeOutPut,
                TypeTestings = typeTestings,
                TypesOutputOfResult = typeOutPut,
            },
            LayoutTestingId = layoutTestingId,
            Questions = questions.Items.ToList(),
        };

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> CreateQuestion(int id)
    {
        return View();
    }
}
