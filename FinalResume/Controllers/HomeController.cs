using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalResume.Data;
using FinalResume.Models;


namespace FinalResume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ResumeContext _context;

        public HomeController(ResumeContext context)
        {
            _context = context;
        }

        // GET: applicants
        public async Task<IActionResult> Index(int? ID)
        {
            //if (ID == null)
            //{
            //    return NotFound();
            //}

            //Returns the first value from the database
            //include and then include
            var applicant = await _context.applicant
                            .AsNoTracking()
                            .Include(e => e.education)
                            .Include(s => s.skills)
                            .Include(x => x.Experiences)
                            .ThenInclude(d => d.duty)
                            .FirstOrDefaultAsync(y => y.FirstName == "Carson");

            return View(applicant);

        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
