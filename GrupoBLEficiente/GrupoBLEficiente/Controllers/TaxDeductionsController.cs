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
    public class TaxDeductionsController : Controller
    {
        private readonly GBLContext _context;

        public TaxDeductionsController(GBLContext context)
        {
            _context = context;
        }

        // GET: TaxDeductions
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaxDeduction.ToListAsync());
        }

        // GET: TaxDeductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxDeduction = await _context.TaxDeduction
                .FirstOrDefaultAsync(m => m.IdTaxDeduction == id);
            if (taxDeduction == null)
            {
                return NotFound();
            }

            return View(taxDeduction);
        }

        // GET: TaxDeductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxDeductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTaxDeduction,Name,Percentage,Description")] TaxDeduction taxDeduction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taxDeduction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxDeduction);
        }

        // GET: TaxDeductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxDeduction = await _context.TaxDeduction.FindAsync(id);
            if (taxDeduction == null)
            {
                return NotFound();
            }
            return View(taxDeduction);
        }

        // POST: TaxDeductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaxDeduction,Name,Percentage,Description")] TaxDeduction taxDeduction)
        {
            if (id != taxDeduction.IdTaxDeduction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxDeduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxDeductionExists(taxDeduction.IdTaxDeduction))
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
            return View(taxDeduction);
        }

        // GET: TaxDeductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxDeduction = await _context.TaxDeduction
                .FirstOrDefaultAsync(m => m.IdTaxDeduction == id);
            if (taxDeduction == null)
            {
                return NotFound();
            }

            return View(taxDeduction);
        }

        // POST: TaxDeductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taxDeduction = await _context.TaxDeduction.FindAsync(id);
            if (taxDeduction != null)
            {
                _context.TaxDeduction.Remove(taxDeduction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxDeductionExists(int id)
        {
            return _context.TaxDeduction.Any(e => e.IdTaxDeduction == id);
        }
    }
}
