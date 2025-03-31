using BASEL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BASEL.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseConnection _context;
        private static readonly HttpClient _httpClient = new HttpClient();

        public AccountController(DatabaseConnection context)
        {
            _context = context;
        }

        // Login Page
        public IActionResult Login() => View();

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

        // Dashboard with Dropdowns and Table Data
        public IActionResult Dashboard()
        {
            // Populate Dropdowns
            ViewBag.MASTER = new SelectList(_context.MASTER.ToList(), "NAME", "NAME");
            ViewBag.PROJECT = new SelectList(_context.PROJECT.ToList(), "NAME", "NAME");
            ViewBag.CIRCLE = new SelectList(_context.CIRCLE.ToList(), "NAME", "NAME");

            var siteList = _context.SITE.ToList();
            var purchasedetailsList = _context.PURCHASE_DETAILS.ToList();
            var masterList = _context.MASTER.ToList();

            // Populate PO IDs
            ViewBag.PoIds = purchasedetailsList.Select(p => new SelectListItem
            {
                Value = p.PO_ID.ToString(),
                Text = p.PO_ID.ToString()
            }).ToList();

            // Populate Site Data
            ViewBag.SiteIds = siteList.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.ID.ToString()
            }).ToList();

            ViewBag.SiteNames = siteList.Select(s => new SelectListItem
            {
                Value = s.NAME.ToString(),
                Text = s.NAME
            }).ToList();

            // Populate Customer Codes from MASTER Table
            ViewBag.CustomerCodes = masterList.Select(s => new SelectListItem
            {
                Value = s.CUSTOMER_CODE.ToString(),
                Text = s.CUSTOMER_CODE
            }).ToList();

            return View();
        }




        public async Task<IActionResult> PurchasePO()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://localhost:5141/api/purchase-po/ListOfPurchasePos");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = $"Failed to load data! Status Code: {response.StatusCode}";
                    return View(new List<PurchasePOViewModel>());
                }

                var data = await response.Content.ReadAsStringAsync();
                var purchasePOList = JsonConvert.DeserializeObject<List<PurchasePOViewModel>>(data);
                return View(purchasePOList);
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Unexpected Error: {ex.Message}";
                return View(new List<PurchasePOViewModel>());
            }
        }

    }
}
