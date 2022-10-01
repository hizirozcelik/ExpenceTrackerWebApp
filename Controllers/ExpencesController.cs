using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenceTrackerWebApp.Data;
using ExpenceTrackerWebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExpenceTrackerWebApp.Controllers
{
    public class ExpencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpencesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: Expences
        public async Task<IActionResult> Index()
        {
            var expences = await _context.Expence.ToListAsync();
            var sorted = expences.OrderByDescending(x => x.ExpenceDate);
            return View(sorted);
        }
        [Authorize]
        // GET: Expences/Create
        public IActionResult Create()
        {
            return View();
        }
     
        // POST: Expences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExpenceDate,Cost,Description")] Expence expence)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expence);
        }
        [Authorize]
        // GET: Expences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expence = await _context.Expence.FindAsync(id);
            if (expence == null)
            {
                return NotFound();
            }
            return View(expence);
        }
        [Authorize]
        // POST: Expences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExpenceDate,Cost,Description")] Expence expence)
        {
            if (id != expence.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenceExists(expence.Id))
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
            return View(expence);
        }
        [Authorize]
        // GET: Expences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expence = await _context.Expence
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expence == null)
            {
                return NotFound();
            }

            return View(expence);
        }
        [Authorize]
        // POST: Expences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expence = await _context.Expence.FindAsync(id);
            _context.Expence.Remove(expence);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenceExists(int id)
        {
            return _context.Expence.Any(e => e.Id == id);
        }
    }
}
