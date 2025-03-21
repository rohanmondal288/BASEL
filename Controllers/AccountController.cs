using BASEL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BASE.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseConnection _context;

        public AccountController(DatabaseConnection context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return RedirectToAction("Dashboard", "Account");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            return View();
        }

        public IActionResult Dashboard()
        {
            // Populate Master, Project, and Circle dropdowns
            ViewBag.MASTER = new SelectList(_context.MASTER.ToList(), "NAME", "NAME");
            ViewBag.PROJECT = new SelectList(_context.PROJECT.ToList(), "NAME", "NAME");
            ViewBag.CIRCLE = new SelectList(_context.CIRCLE.ToList(), "NAME", "NAME");

            // Fetch SITE data for Site ID and Site Name
            var siteList = _context.SITE.ToList();

            // Separate for Site ID and Site Name
            ViewBag.SiteIds = siteList.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.ID.ToString()
            }).ToList();

            ViewBag.SiteNames = siteList.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.NAME
            }).ToList();

            return View();
        }
    }
}
