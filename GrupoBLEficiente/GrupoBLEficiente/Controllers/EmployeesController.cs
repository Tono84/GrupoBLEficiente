using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GrupoBLEficiente.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index()
        {
            List<Employees> employees = new List<Employees>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Employees").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<Employees>>(data);
            }

            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            Employees employee = new Employees();
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/Employees/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                
                string data = await response.Content.ReadAsStringAsync();
                employee = JsonConvert.DeserializeObject<Employees>(data);
                HttpResponseMessage jobTitleResponse = await _client.GetAsync($"{_client.BaseAddress}/JobTitles/{employee.IdJobTitle}");

                if (jobTitleResponse.IsSuccessStatusCode)
                {
                    string jobTitleData = await jobTitleResponse.Content.ReadAsStringAsync();
                    JobTitles jobTitle = JsonConvert.DeserializeObject<JobTitles>(jobTitleData);

                    
                    employee.JobTitles = jobTitle;
                }

                // Obtiene el tipo de Id por ID de empleado
                HttpResponseMessage nationalIdTypeResponse = await _client.GetAsync($"{_client.BaseAddress}/NationalIdTypes/{employee.IdType}");

                if (nationalIdTypeResponse.IsSuccessStatusCode)
                {
                    string nationalIdTypeData = await nationalIdTypeResponse.Content.ReadAsStringAsync();
                    NationalIdTypes nationalIdType = JsonConvert.DeserializeObject<NationalIdTypes>(nationalIdTypeData);

                    // Asignar el tipo de identificación nacional al empleado
                    employee.NationalIdTypes = nationalIdType;
                }
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var nationalIdTypes = await GetNationalIdTypes();
            ViewBag.NationalIdTypes = new SelectList(nationalIdTypes, "IdType", "Name");
            var jobTitles = await GetJobTitles();
            ViewBag.JobTitles = new SelectList(jobTitles, "IdJobTitle", "Name");
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Employees employees)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var nationalIdTypes = await GetNationalIdTypes();
        //        ViewBag.NationalIdTypes = new SelectList(nationalIdTypes, "IdType", "Name");
        //        var jobTitles = await GetJobTitles();
        //        ViewBag.JobTitles = new SelectList(jobTitles, "IdJobTitle", "Name");
        //        string data = JsonConvert.SerializeObject(employees);
        //        StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = _client.PostAsync($"{_client.BaseAddress}/Employees", content).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            TempData["successMessage"] = "Nuevo Empleado Registrado";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["errorMessage"] = "Error al intentar registrar el nuevo empleado";
        //            return View();
        //        }

        //    }return View(employees);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Employees employees)
        {
            if (ModelState.IsValid)
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
            else
            {
       
                var nationalIdTypes = await GetNationalIdTypes();
                ViewBag.NationalIdTypes = new SelectList(nationalIdTypes, "IdType", "Name");
                var jobTitles = await GetJobTitles();
                ViewBag.JobTitles = new SelectList(jobTitles, "IdJobTitle", "Name");

                return View(employees);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var nationalIdTypes = await GetNationalIdTypes();
            ViewBag.NationalIdTypes = new SelectList(nationalIdTypes, "IdType", "Name");
            var jobTitles = await GetJobTitles();
            ViewBag.JobTitles = new SelectList(jobTitles, "IdJobTitle", "Name");

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
        public async Task<IActionResult> Edit(int id, Employees employees) 
        {

            string data = JsonConvert.SerializeObject(employees);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync($"{_client.BaseAddress}/Employees/{id}", content).Result; 
            if (response.IsSuccessStatusCode)
            {
                TempData["successMessage"] = "Empleado Editado Exitosamente";
                return RedirectToAction("Index");
            }
            var nationalIdTypesTask = GetNationalIdTypes();
            var jobTitlesTask = GetJobTitles();
            await Task.WhenAll(nationalIdTypesTask, jobTitlesTask);
            ViewBag.NationalIdTypes = new SelectList(nationalIdTypesTask.Result, "IdType", "Name");
            ViewBag.JobTitles = new SelectList(jobTitlesTask.Result, "IdJobTitle", "Name");
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
        private async Task<List<NationalIdTypes>> GetNationalIdTypes()
        {
            List<NationalIdTypes> nationalIdTypes = new List<NationalIdTypes>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/NationalIdTypes").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                nationalIdTypes = JsonConvert.DeserializeObject<List<NationalIdTypes>>(data);
            }

            return nationalIdTypes;
        }
        private async Task<List<JobTitles>> GetJobTitles()
        {
            List<JobTitles> jobTitles = new List<JobTitles>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/JobTitles").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                jobTitles = JsonConvert.DeserializeObject<List<JobTitles>>(data);
            }

            return jobTitles;
        }

    }

}

