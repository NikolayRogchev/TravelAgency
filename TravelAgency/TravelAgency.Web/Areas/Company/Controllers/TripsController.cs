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
using static TravelAgency.Common.Enums;

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
        public IActionResult Index(int id)
        {
            if (!this.companies.CompanyExist(id))
            {
                TempData["ErrorMessage"] = "This company does not exist";
                return RedirectToAction(nameof(Index), "Home", null);
            }
            IEnumerable<CompanyTripListingServiceModel> trips = this.trips.AllByCompany(id);
            string companyName = this.companies.GetName(id)?.Name;
            return View(new CompanyTripListingViewModel { Company = companyName, Trips = trips });
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> countries = this.countries.All()
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            IEnumerable<SelectListItem> companies = this.companies.AllByUser(User.Identity.Name)
                .Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
            this.AddNotification("Trip created!", NotificationType.Success);
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
            this.trips.Create(model.Name, model.Company, model.Destination, model.Capacity, model.Price, model.StartDate, model.EndDate);
            return RedirectToAction(nameof(Index), new { id = model.Company });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}