﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        [Authorize(Policy = "Student")]
        public async Task<IActionResult> HomeUser()
        {
            return View();
        }
    }
}
