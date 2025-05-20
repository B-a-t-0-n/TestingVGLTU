using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestingVGLTU.LayoutTestings.Application.Commands.LayoutTestings.Delete;
using TestingVGLTU.LayoutTestings.Application.Queries.LayoutTestings.GetLayoutTestingsWithPaginationFiltration;
using TestingVGLTU.LayoutTestings.Application.Queries.TypeTestings.GetTypeTestingAll;
using TestingVGLTU.Models.ViewModel;

namespace TestingVGLTU.Controllers;


public class CardsController : Controller
{
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
    public async Task<IActionResult> TestingEditor(
        [FromServices] GetLayoutTestingsWithPaginationFiltrationHandler layoutTestingsHandler,
        [FromServices] GetTypeTestingsAllHandler typeTestingsHandler,
        CancellationToken cancellationToken)
    {
        var id = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

        var layoutTestings = await layoutTestingsHandler.Handle(
            new GetLayoutTestingsWithPaginationFiltrationQuery(
                id,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                1,
                100),
            cancellationToken);

        var typeTestings = await typeTestingsHandler.Handle(
            new GetTypeTestingsAllQuery(null, null),
            cancellationToken); 

        var model = new TestingEditorCardsViewModel
        {
            LayoutTestings = layoutTestings.Items.ToList(),
            TypeTestings = typeTestings,
            TeacherName = User.FindFirst(ClaimTypes.Name)?.Value ?? "",
        };


        return View(model);
    }

    [HttpPost]
    [Authorize(Policy = "Teacher")]
    public async Task<IActionResult> DeleteTesting(
        [FromServices] DeleteLayoutTestingHandler handler,
        Guid testingId,
        CancellationToken cancellationToken)
    {
       var result = await handler.Handle(
            new DeleteLayoutTestingCommand(testingId),
            cancellationToken);
        
        return RedirectToAction("TestingEditor");
    }
}
