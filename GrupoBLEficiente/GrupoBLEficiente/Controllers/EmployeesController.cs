using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoBLEficiente.Models;
using GrupoBLEficiente.Helpers;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;


namespace GrupoBLEficiente.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;

        Uri baseAddress = new Uri("http://localhost:5151/api");
        private readonly HttpClient _client;


        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Employees> employees = new List<Employees>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees").Result;

            if (response.IsSuccessStatusCode)
            {
                string data =response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employees>>(data);
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employees employees)
        {
            string data = JsonConvert.SerializeObject(employees);
            StringContent content = new StringContent(data, Encoding.UTF8, "aplication/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Employees/Post", content).Result;
                if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Nuevo Empleado Registrado";
                return View("Index");
            }
                return View();
        }
        //GrupoBLEficienteAPI api = new GrupoBLEficienteAPI();

        //// GET: Employees
        //public async Task<IActionResult> Index()
        //{
        //    List<Employees> employees = new List<Employees>();
        //    HttpClient client = api.Initial();
        //    HttpResponseMessage response = await client.GetAsync("api/Employees");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = response.Content.ReadAsStringAsync().Result;
        //        employees = JsonSerializer.Deserialize<List<Employees>>(result);
        //    }
        //    return View(employees);
        //}

        //// GET: Employees/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    HttpClient client = api.Initial();
        //    HttpResponseMessage response = await client.GetAsync("api/Employees");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var employee = await response.Content.ReadFromJsonAsync<Employees>();
        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(employee);
        //    }
        //    else
        //    {
        //        // Manejar error del API
        //        return RedirectToAction(nameof(Index));
        //    }
        //}

        //// GET: Employees/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}


        //// POST: Employees/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdEmployee,Name,LastName,NationalId,Phone,Email,Password,AccruedVacations,BirthDate,JobTitle,MonthlySalary,FirstDay,Schedule,IdRol,Status,Description")] Employees employees)
        //{
        //    var response = await api.PostEmployees(employees);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        // Manejar error del API
        //        return View(employees);
        //    }
        //}
        //// GET: Employees/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employees = await _context.Employees.FindAsync(id);
        //    if (employees == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Description", employees.IdRol);
        //    return View(employees);
        //}

        //// POST: Employees/Edit/5

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("IdEmployee,Name,LastName,NationalId,Phone,Email,Password,AccruedVacations,BirthDate,JobTitle,MonthlySalary,FirstDay,Schedule,IdRol,Status,Description")] Employees employees)
        //{
        //    if (id != employees.IdEmployee)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employees);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeesExists(employees.IdEmployee))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Description", employees.IdRol);
        //    return View(employees);
        //}

        //// GET: Employees/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employees = await _context.Employees
        //        .Include(e => e.Roles)
        //        .FirstOrDefaultAsync(m => m.IdEmployee == id);
        //    if (employees == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employees);
        //}

        //// POST: Employees/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var employees = await _context.Employees.FindAsync(id);
        //    if (employees != null)
        //    {
        //        _context.Employees.Remove(employees);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}
