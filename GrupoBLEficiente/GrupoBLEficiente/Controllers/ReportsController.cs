using Microsoft.AspNetCore.Mvc;

namespace GrupoBLEficiente.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
