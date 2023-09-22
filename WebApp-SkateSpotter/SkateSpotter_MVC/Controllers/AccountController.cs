using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkateSpotter_MVC.Data;
using SkateSpotter_MVC.Models;

namespace SkateSpotter_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AccountController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
              return _context.Skaters != null ? 
                          View(await _context.Skaters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.Skaters'  is null.");
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skaters == null)
            {
                return NotFound();
            }

            var skater = await _context.Skaters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skater == null)
            {
                return NotFound();
            }

            return View(skater);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,Username")] Skater skater)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skater);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skater);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skaters == null)
            {
                return NotFound();
            }

            var skater = await _context.Skaters.FindAsync(id);
            if (skater == null)
            {
                return NotFound();
            }
            return View(skater);
        }

        // POST: Account/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,Username")] Skater skater)
        {
            if (id != skater.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skater);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkaterExists(skater.Id))
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
            return View(skater);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skaters == null)
            {
                return NotFound();
            }

            var skater = await _context.Skaters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skater == null)
            {
                return NotFound();
            }

            return View(skater);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skaters == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Skaters'  is null.");
            }
            var skater = await _context.Skaters.FindAsync(id);
            if (skater != null)
            {
                _context.Skaters.Remove(skater);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkaterExists(int id)
        {
          return (_context.Skaters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
