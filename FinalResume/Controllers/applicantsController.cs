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
    public class applicantsController : Controller
    {
        private readonly ResumeContext _context;

        public applicantsController(ResumeContext context)
        {
            _context = context;
        }

        // GET: applicants
        public async Task<IActionResult> Index()
        {
            return View(await _context.applicant.ToListAsync());
        }

        // GET: applicants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.applicant
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // GET: applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: applicants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,City,State,Phone,Email,WebAddress,skillsId,educationID,referenceID")] applicant applicant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicant);
        }

        // GET: applicants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.applicant.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: applicants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,City,State,Phone,Email,WebAddress,skillsId,educationID,referenceID")] applicant applicant)
        {
            if (id != applicant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!applicantExists(applicant.ID))
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
            return View(applicant);
        }

        // GET: applicants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicant = await _context.applicant
                .FirstOrDefaultAsync(m => m.ID == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        // POST: applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicant = await _context.applicant.FindAsync(id);
            _context.applicant.Remove(applicant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool applicantExists(int id)
        {
            return _context.applicant.Any(e => e.ID == id);
        }
    }
}
