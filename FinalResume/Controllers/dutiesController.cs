using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalResume.Data;
using FinalResume.Models;

namespace FinalResume.Controllers
{
    public class dutiesController : Controller
    {
        private readonly ResumeContext _context;

        public dutiesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: duties
        public async Task<IActionResult> Index()
        {
            return View(await _context.duties.ToListAsync());
        }

        // GET: duties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duties = await _context.duties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duties == null)
            {
                return NotFound();
            }

            return View(duties);
        }

        // GET: duties/Create
        public IActionResult Create()
        {

            ViewData["experienceID"] = new SelectList(_context.experience, "ID", "placeWorked");
            return View();
        }

        // POST: duties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,summary,experienceID")] duties duties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duties);
        }

        // GET: duties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duties = await _context.duties.FindAsync(id);
            ViewData["experienceID"] = new SelectList(_context.experience, "ID", "placeWorked", duties.experienceID);
            if (duties == null)
            {
                return NotFound();
            }
            return View(duties);
        }

        // POST: duties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,summary,experienceID")] duties duties)
        {
            if (id != duties.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dutiesExists(duties.ID))
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
            ViewData["experienceID"] = new SelectList(_context.experience, "ID", "placeWorked", duties.experienceID);
            return View(duties);
        }

        // GET: duties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duties = await _context.duties
                .FirstOrDefaultAsync(m => m.ID == id);
            if (duties == null)
            {
                return NotFound();
            }

            return View(duties);
        }

        // POST: duties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duties = await _context.duties.FindAsync(id);
            _context.duties.Remove(duties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool dutiesExists(int id)
        {
            return _context.duties.Any(e => e.ID == id);
        }
    }
}
