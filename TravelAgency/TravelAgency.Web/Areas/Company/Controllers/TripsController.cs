using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Trips;
using TravelAgency.Web.Areas.Company.ViewModels;

namespace TravelAgency.Web.Areas.Company.Controllers
{
    public class TripsController : BaseCompanyController
    {
        private readonly ICompanyService companies;
        private readonly ITripService trips;
        private readonly ICountryService countries;
        private readonly UserManager<User> userManager;
        public TripsController(ICompanyService companies, ITripService trips, ICountryService countries, UserManager<User> userManager)
        {
            this.companies = companies;
            this.trips = trips;
            this.countries = countries;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(int id)
        {
            if (!this.companies.CompanyExist(id))
            {
                TempData["ErrorMessage"] = "This company does not exist";
                return RedirectToAction(nameof(Index), "Home", null);
            }
            User user = await this.userManager.FindByNameAsync(User.Identity.Name);
            IEnumerable<TripListingServiceModel> trips = this.trips.All(id, user.Id);
            string companyName = this.companies.GetName(id)?.Name;
            return View(new TripListingViewModel { Company = companyName, Trips = trips });
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> countries = this.countries.All()
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            IEnumerable<SelectListItem> companies = this.companies.AllByUser(User.Identity.Name)
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            return View(new CreateTripViewModel { Companies = companies, Countries = countries });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTripViewModel model)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<SelectListItem> countries = this.countries.All()
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
                IEnumerable<SelectListItem> companies = this.companies.AllByUser(User.Identity.Name)
                    .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
                return View(new CreateTripViewModel { Companies = companies, Countries = countries });
            }
            this.trips.Create(model.Name, model.Company, model.Destination, model.Capacity, model.Duration, model.Price);
            return RedirectToAction(nameof(Index), new { id = model.Company });
        }
    }
}