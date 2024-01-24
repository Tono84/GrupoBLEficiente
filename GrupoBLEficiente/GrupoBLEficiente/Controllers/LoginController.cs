using Microsoft.AspNetCore.Mvc;

namespace GrupoBLEficiente.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
