using Microsoft.AspNetCore.Mvc;
using TestingVGLTU.Data;

namespace TestingVGLTU.Controllers
{
    public class AuthorizationController : Controller
    {
        DataContext dataContext;

        public AuthorizationController (DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IActionResult Login()
        {
            
            return View();
        }
    }
}
