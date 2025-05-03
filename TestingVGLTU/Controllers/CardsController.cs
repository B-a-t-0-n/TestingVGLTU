using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> TestingEditor()
    {
        
        return View();
    }

    [HttpPost]
    [Authorize(Policy = "Teacher")]
    public async Task<IActionResult> DeleteTesting(int testingId)
    {
       
        return RedirectToAction("TestingEditor");
    }
}
