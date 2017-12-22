using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

            return View(new CreateTripViewModel
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Companies = companies,
                Countries = countries
            });
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
                model.Companies = companies;
                model.Countries = countries;
                return View(model);
            }
            this.trips.Create(model.Name, model.Company, model.Destination, model.Capacity, model.Price, model.StartDate, model.EndDate);
            this.AddTempDataNotification("Trip created!", NotificationType.Success);
            return RedirectToAction(nameof(Index), new { id = model.Company });
        }

        public IActionResult Delete(int id)
        {
            this.trips.Delete(id);
            return NoContent();
        }

        public IActionResult Edit(int id)
        {
            EditTripServiceModel editTrip = this.trips.Find(id);
            //IEnumerable<SelectListItem> countries = this.countries.All()
            //    .Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString(),
            //        Selected = editTrip.DestinationId == c.Id
            //    });
            //IEnumerable<SelectListItem> companies = this.companies.AllByUser(User.Identity.Name)
            //    .Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.Id.ToString(),
            //        Selected = c.Id == companyId
            //    });

            //return View(new EditTripViewModel { Trip = editTrip/*, Companies = companies, Countries = countries*/ });
            return View(editTrip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditTripServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            this.trips.Edit(model.Id, model.Name, /*int.Parse(model.Trip.CompanyName), int.Parse(model.Trip.Destination),*/ model.Capacity, model.Price, model.StartDate, model.EndDate);
            this.AddTempDataNotification("Trip updated", NotificationType.Success);
            return RedirectToAction(nameof(Index), new { id = model.CompanyId });
        }
    }
}