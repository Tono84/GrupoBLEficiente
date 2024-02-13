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
using System.Net.Http;



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
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees").Result;
            List<Employees> employees = new List<Employees>();
            List<JobTitles> jobTitles = new List<JobTitles>(); 

            
        
            if (response.IsSuccessStatusCode)
            {
                
                string data =response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employees>>(data);
            }
            HttpResponseMessage jobTitlesResponse = _client.GetAsync(_client.BaseAddress + "/JobTitles").Result;

            if (jobTitlesResponse.IsSuccessStatusCode)
            {
                string jobTitlesData = jobTitlesResponse.Content.ReadAsStringAsync().Result;
                jobTitles = JsonConvert.DeserializeObject<List<JobTitles>>(jobTitlesData);
            }

            ViewBag.JobTitles = new SelectList(jobTitles, "Id", "Name");
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
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync($"{_client.BaseAddress}/Employees", content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Nuevo Empleado Registrado";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Error al intentar registrar el nuevo empleado";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employees employees = new Employees();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/Employees/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<Employees>(data);
            }
            return View(employees);
        }

        [HttpPost]
        public IActionResult Edit(int id, Employees employees) 
        {
            string data = JsonConvert.SerializeObject(employees);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync($"{_client.BaseAddress}/Employees/{id}", content).Result; 
            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Empleado Editado Exitosamente";
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employees employees = new Employees();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/Employees/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<Employees>(data);
            }
            return View(employees);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync($"{_client.BaseAddress}/Employees/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Empleado eliminado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = "Error al intentar eliminar el empleado";
                return RedirectToAction("Index");
            }
        }



    }
}
