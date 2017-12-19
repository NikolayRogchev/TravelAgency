using Microsoft.AspNetCore.Mvc;
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
        public TripsController(ICompanyService companies, ITripService trips)
        {
            this.companies = companies;
            this.trips = trips;
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
    }
}