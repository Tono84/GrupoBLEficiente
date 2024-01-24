using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoBLEficiente.Models;

namespace GrupoBLEficiente.Controllers
{
    public class PaysheetsController : Controller
    {
        private readonly GBLContext _context;

        public PaysheetsController(GBLContext context)
        {
            _context = context;
        }

        // GET: Paysheets
        public async Task<IActionResult> Index()
        {
            var gBLContext = _context.Paysheet.Include(p => p.Attendance).Include(p => p.CCSSDeductions).Include(p => p.Employees).Include(p => p.TaxDeduction);
            return View(await gBLContext.ToListAsync());
        }

        // GET: Paysheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paysheet = await _context.Paysheet
                .Include(p => p.Attendance)
                .Include(p => p.CCSSDeductions)
                .Include(p => p.Employees)
                .Include(p => p.TaxDeduction)
                .FirstOrDefaultAsync(m => m.IdPaysheet == id);
            if (paysheet == null)
            {
                return NotFound();
            }

            return View(paysheet);
        }

        // GET: Paysheets/Create
        public IActionResult Create()
        {
            ViewData["IdAttendance"] = new SelectList(_context.Attendance, "IdAttendance", "Description");
            ViewData["IdCCSSDeduction"] = new SelectList(_context.CCSSDeductions, "IdCCSSDeductions", "Description");
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "IdEmployee", "Email");
            ViewData["IdTaxDeduction"] = new SelectList(_context.TaxDeduction, "IdTaxDeduction", "Description");
            return View();
        }

        // POST: Paysheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaysheet,IdEmployee,IdAttendance,EmployeeFullName,EmployeeNationalId,PayPeriod,GrossSalary,BiweeklyGrossSalary,Comissions,OnCall,Vacations,TotalPay,OtherSalary,AbsencesDeductions,IdCCSSDeduction,IdTaxDeduction,OtherDeductions,NetPay,Description")] Paysheet paysheet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paysheet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAttendance"] = new SelectList(_context.Attendance, "IdAttendance", "Description", paysheet.IdAttendance);
            ViewData["IdCCSSDeduction"] = new SelectList(_context.CCSSDeductions, "IdCCSSDeductions", "Description", paysheet.IdCCSSDeduction);
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "IdEmployee", "Email", paysheet.IdEmployee);
            ViewData["IdTaxDeduction"] = new SelectList(_context.TaxDeduction, "IdTaxDeduction", "Description", paysheet.IdTaxDeduction);
            return View(paysheet);
        }

        // GET: Paysheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paysheet = await _context.Paysheet.FindAsync(id);
            if (paysheet == null)
            {
                return NotFound();
            }
            ViewData["IdAttendance"] = new SelectList(_context.Attendance, "IdAttendance", "Description", paysheet.IdAttendance);
            ViewData["IdCCSSDeduction"] = new SelectList(_context.CCSSDeductions, "IdCCSSDeductions", "Description", paysheet.IdCCSSDeduction);
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "IdEmployee", "Email", paysheet.IdEmployee);
            ViewData["IdTaxDeduction"] = new SelectList(_context.TaxDeduction, "IdTaxDeduction", "Description", paysheet.IdTaxDeduction);
            return View(paysheet);
        }

        // POST: Paysheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPaysheet,IdEmployee,IdAttendance,EmployeeFullName,EmployeeNationalId,PayPeriod,GrossSalary,BiweeklyGrossSalary,Comissions,OnCall,Vacations,TotalPay,OtherSalary,AbsencesDeductions,IdCCSSDeduction,IdTaxDeduction,OtherDeductions,NetPay,Description")] Paysheet paysheet)
        {
            if (id != paysheet.IdPaysheet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paysheet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaysheetExists(paysheet.IdPaysheet))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAttendance"] = new SelectList(_context.Attendance, "IdAttendance", "Description", paysheet.IdAttendance);
            ViewData["IdCCSSDeduction"] = new SelectList(_context.CCSSDeductions, "IdCCSSDeductions", "Description", paysheet.IdCCSSDeduction);
            ViewData["IdEmployee"] = new SelectList(_context.Employees, "IdEmployee", "Email", paysheet.IdEmployee);
            ViewData["IdTaxDeduction"] = new SelectList(_context.TaxDeduction, "IdTaxDeduction", "Description", paysheet.IdTaxDeduction);
            return View(paysheet);
        }

        // GET: Paysheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paysheet = await _context.Paysheet
                .Include(p => p.Attendance)
                .Include(p => p.CCSSDeductions)
                .Include(p => p.Employees)
                .Include(p => p.TaxDeduction)
                .FirstOrDefaultAsync(m => m.IdPaysheet == id);
            if (paysheet == null)
            {
                return NotFound();
            }

            return View(paysheet);
        }

        // POST: Paysheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paysheet = await _context.Paysheet.FindAsync(id);
            if (paysheet != null)
            {
                _context.Paysheet.Remove(paysheet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaysheetExists(int id)
        {
            return _context.Paysheet.Any(e => e.IdPaysheet == id);
        }
    }
}
