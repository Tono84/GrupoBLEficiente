using GrupoBLEficiente.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GrupoBLEficiente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5151/api");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int activeEmployeesCount = await GetActiveEmployeesCount();

            ViewBag.ActiveEmployeesCount = activeEmployeesCount;

            return View();
        }

        private async Task<int> GetActiveEmployeesCount()
        {
            List<Employees> employees = new List<Employees>();
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Employees");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employees>>(data);
            }

            return employees.Count(e => e.Status == "Activo");
        }
    

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
