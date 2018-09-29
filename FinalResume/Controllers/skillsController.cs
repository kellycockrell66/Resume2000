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
    public class skillsController : Controller
    {
        private readonly ResumeContext _context;

        public skillsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: skills
        public async Task<IActionResult> Index()
        {
            return View(await _context.skills.ToListAsync());
        }

        // GET: skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.skills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // GET: skills/Create
        public IActionResult Create()
        {
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID");
            return View();
        }

        // POST: skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,skillName,experienceLevel,yearsUsed,applicantID")] skills skills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skills);
        }

        // GET: skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.skills.FindAsync(id);
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", skills.applicantID);
            if (skills == null)
            {
                return NotFound();
            }
            return View(skills);
        }

        // POST: skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,skillName,experienceLevel,yearsUsed,applicantID")] skills skills)
        {
            if (id != skills.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!skillsExists(skills.ID))
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
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", skills.applicantID);
            return View(skills);
        }

        // GET: skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skills = await _context.skills
                .FirstOrDefaultAsync(m => m.ID == id);
            if (skills == null)
            {
                return NotFound();
            }

            return View(skills);
        }

        // POST: skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skills = await _context.skills.FindAsync(id);
            _context.skills.Remove(skills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool skillsExists(int id)
        {
            return _context.skills.Any(e => e.ID == id);
        }
    }
}
