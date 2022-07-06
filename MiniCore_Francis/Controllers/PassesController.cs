using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniCore_Francis.Data;
using MiniCore_Francis.Models;

namespace MiniCore_Francis.Controllers
{
    public class PassesController : Controller
    {
        private readonly AppDBContext _context;

        public PassesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Passes
        public async Task<IActionResult> Index()
        {
              return _context.passes != null ? 
                          View(await _context.passes.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.passes'  is null.");
        }

        // GET: Passes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.passes == null)
            {
                return NotFound();
            }

            var pass = await _context.passes
                .FirstOrDefaultAsync(m => m.PassID == id);
            if (pass == null)
            {
                return NotFound();
            }

            return View(pass);
        }

        // GET: Passes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassID,Type,Quota,Passes,Cost")] Pass pass)
        {
            if (ModelState.IsValid)
            {
                pass.Cost = (decimal)pass.Passes / (decimal)pass.Quota;
                _context.Add(pass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pass);
        }

        // GET: Passes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.passes == null)
            {
                return NotFound();
            }

            var pass = await _context.passes.FindAsync(id);
            if (pass == null)
            {
                return NotFound();
            }
            return View(pass);
        }

        // POST: Passes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PassID,Type,Quota,Passes,Cost")] Pass pass)
        {
            if (id != pass.PassID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassExists(pass.PassID))
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
            return View(pass);
        }

        // GET: Passes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.passes == null)
            {
                return NotFound();
            }

            var pass = await _context.passes
                .FirstOrDefaultAsync(m => m.PassID == id);
            if (pass == null)
            {
                return NotFound();
            }

            return View(pass);
        }

        // POST: Passes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.passes == null)
            {
                return Problem("Entity set 'AppDBContext.passes'  is null.");
            }
            var pass = await _context.passes.FindAsync(id);
            if (pass != null)
            {
                _context.passes.Remove(pass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassExists(int id)
        {
          return (_context.passes?.Any(e => e.PassID == id)).GetValueOrDefault();
        }
    }
}
