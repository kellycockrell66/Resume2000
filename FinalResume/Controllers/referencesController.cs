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
    public class referencesController : Controller
    {
        private readonly ResumeContext _context;

        public referencesController(ResumeContext context)
        {
            _context = context;
        }

        // GET: references
        public async Task<IActionResult> Index()
        {
            return View(await _context.references.ToListAsync());
        }

        // GET: references/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.references
                .FirstOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }

            return View(references);
        }

        // GET: references/Create
        public IActionResult Create()
        {
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID");
            return View();
        }

        // POST: references/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,firstName,lastName,companyName,mailingAddress,city,state,emailAddress,phone, applicantID")] references references)
        {
            if (ModelState.IsValid)
            {
                _context.Add(references);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(references);
        }

        // GET: references/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.references.FindAsync(id);
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", references.applicantID);
            if (references == null)
            {
                return NotFound();
            }
            return View(references);
        }

        // POST: references/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,firstName,lastName,companyName,mailingAddress,city,state,emailAddress,phone,applicantID")] references references)
        {
            if (id != references.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(references);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!referencesExists(references.ID))
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
            ViewData["applicantID"] = new SelectList(_context.applicant, "ID", "ID", references.applicantID);
            return View(references);
        }

        // GET: references/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var references = await _context.references
                .FirstOrDefaultAsync(m => m.ID == id);
            if (references == null)
            {
                return NotFound();
            }

            return View(references);
        }

        // POST: references/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var references = await _context.references.FindAsync(id);
            _context.references.Remove(references);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool referencesExists(int id)
        {
            return _context.references.Any(e => e.ID == id);
        }
    }
}
