using Microsoft.AspNetCore.Mvc;

namespace ApiTechOil.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
