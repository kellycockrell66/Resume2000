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
    public class ExperienceController : Controller
    {
        private readonly ResumeContext _context;

        public ExperienceController(ResumeContext context)
        {
            _context = context;
        }

        // GET: Experience
        public async Task<IActionResult> Index()
        {
            return View(await _context.experience.ToListAsync());
        }

        // GET: Experience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.experience
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experience/Create
        public IActionResult Create()
        {
            ViewData["applicantID"] = new SelectList(_context.experience, "ID", "ID");
            return View();
        }

        // POST: Experience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,jobName,placeWorked,startDate,endDate,city,state, applicantID")] Experience experience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["applicant"] = new SelectList(_context.applicant, "ID", "ID", experience.ID);
            return View(experience);
        }

        // GET: Experience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.experience.FindAsync(id);
            if (experience == null)
            {
                ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", experience.applicantID);
                return NotFound();
            }
            return View(experience);
        }

        // POST: Experience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,jobName,placeWorked,startDate,endDate,city,state,applicantID")] Experience experience)
        {
            if (id != experience.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.ID))
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
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", experience.applicantID);
            return View(experience);
        }

        // GET: Experience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.experience
                .FirstOrDefaultAsync(m => m.ID == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.experience.FindAsync(id);
            _context.experience.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
            return _context.experience.Any(e => e.ID == id);
        }
    }
}
