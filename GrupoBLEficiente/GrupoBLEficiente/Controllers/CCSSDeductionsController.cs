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
    public class CCSSDeductionsController : Controller
    {
        private readonly GBLContext _context;

        public CCSSDeductionsController(GBLContext context)
        {
            _context = context;
        }

        // GET: CCSSDeductions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CCSSDeductions.ToListAsync());
        }

        // GET: CCSSDeductions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCSSDeductions = await _context.CCSSDeductions
                .FirstOrDefaultAsync(m => m.IdCCSSDeduction == id);
            if (cCSSDeductions == null)
            {
                return NotFound();
            }

            return View(cCSSDeductions);
        }

        // GET: CCSSDeductions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CCSSDeductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCCSSDeduction,Name,Percentage,Description")] CCSSDeductions cCSSDeductions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCSSDeductions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCSSDeductions);
        }

        // GET: CCSSDeductions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCSSDeductions = await _context.CCSSDeductions.FindAsync(id);
            if (cCSSDeductions == null)
            {
                return NotFound();
            }
            return View(cCSSDeductions);
        }

        // POST: CCSSDeductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCCSSDeduction,Name,Percentage,Description")] CCSSDeductions cCSSDeductions)
        {
            if (id != cCSSDeductions.IdCCSSDeduction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCSSDeductions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CCSSDeductionsExists(cCSSDeductions.IdCCSSDeduction))
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
            return View(cCSSDeductions);
        }

        // GET: CCSSDeductions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cCSSDeductions = await _context.CCSSDeductions
                .FirstOrDefaultAsync(m => m.IdCCSSDeduction == id);
            if (cCSSDeductions == null)
            {
                return NotFound();
            }

            return View(cCSSDeductions);
        }

        // POST: CCSSDeductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cCSSDeductions = await _context.CCSSDeductions.FindAsync(id);
            if (cCSSDeductions != null)
            {
                _context.CCSSDeductions.Remove(cCSSDeductions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CCSSDeductionsExists(int id)
        {
            return _context.CCSSDeductions.Any(e => e.IdCCSSDeduction == id);
        }
    }
}
