                                                                              using BASEL.Models;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BASE.Controllers
{
    public class AccountController : Controller
    {
        //for db connection while dropdown
        private readonly DatabaseConnection _context;
        private static readonly HttpClient _httpClient = new HttpClient();



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
            //FOR LABEL
            // Populate Master, Project, and Circle dropdowns
            ViewBag.MASTER = new SelectList(_context.MASTER.ToList(), "NAME", "NAME");
            ViewBag.PROJECT = new SelectList(_context.PROJECT.ToList(), "NAME", "NAME");
            ViewBag.CIRCLE = new SelectList(_context.CIRCLE.ToList(), "NAME", "NAME");

            // Fetch SITE data for Site ID and Site Name
            var siteList = _context.SITE.ToList();


            //FETCH FROM PURCHASE DETAILS 
            var purchasedetailsList = _context.PURCHASE_DETAILS.ToList();



            //FOR TABEL
            // Separate for Site ID and Site Name and CODE 
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

            ViewBag.SiteCodes = siteList.Select(s => new SelectListItem
            {
                Value = s.ID.ToString(),
                Text = s.CODE.ToString()
            }).ToList();

            //POID FETCHING CHILD TABLE
            ViewBag.PoIds = purchasedetailsList.Select(p => new SelectListItem
            {
                Value = p.PO_ID.ToString(),
                Text = p.PO_ID.ToString()
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
            catch (HttpRequestException ex)
            {
                ViewBag.Error = $"HTTP Error: {ex.Message}";
            }
            catch (JsonSerializationException ex)
            {
                ViewBag.Error = $"Serialization Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                ViewBag.Error = $"Unexpected Error: {ex.Message}";
            }

            return View(new List<PurchasePOViewModel>());
        }




    }
}