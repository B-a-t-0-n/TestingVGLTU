﻿using Microsoft.AspNetCore.Mvc;

namespace TestingVGLTU.Controllers
{
    public class CreateTestingController : Controller
    {
        public IActionResult CreateQuestion()
        {
            return View();
        }

        public IActionResult CreateTesting()
        {
            return View();
        }

        public IActionResult TestingEditor()
        {
            return View();
        }
    }
}
