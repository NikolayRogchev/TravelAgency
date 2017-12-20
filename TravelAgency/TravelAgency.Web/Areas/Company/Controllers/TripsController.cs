using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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
        public TripsController(ICompanyService companies, ITripService trips, ICountryService countries)
        {
            this.companies = companies;
            this.trips = trips;
            this.countries = countries;
        }
        public IActionResult Index(int id)
        {
            if (!this.companies.CompanyExist(id))
            {
                TempData["ErrorMessage"] = "This company does not exist";
                return RedirectToAction(nameof(Index), "Home", null);
            }
            IEnumerable<TripListingServiceModel> trips = this.trips.All(id);
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