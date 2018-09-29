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
    public class educationController : Controller
    {
        private readonly ResumeContext _context;

        public educationController(ResumeContext context)
        {
            _context = context;
        }

        // GET: education
        public async Task<IActionResult> Index()
        {
            return View(await _context.education.ToListAsync());
        }

        // GET: education/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.education
                .FirstOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: education/Create
        public IActionResult Create()
        {
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID");
            return View();
            
        }

        // POST: education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,degreeType,subject,institution,city,state,gradDate,applicantID")] education education)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education);
        }

        // GET: education/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.education.FindAsync(id);
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", education.applicantID);

            if (education == null)
            {
                return NotFound();
            }
            return View(education);
        }

        // POST: education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,degreeType,subject,institution,city,state,gradDate,applicantID")] education education)
        {
            if (id != education.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!educationExists(education.ID))
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
            return View(education);
        }

        // GET: education/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.education
                .FirstOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.education.FindAsync(id);
            _context.education.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool educationExists(int id)
        {
            return _context.education.Any(e => e.ID == id);
        }
    }
}
