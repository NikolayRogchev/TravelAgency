using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Web.ViewModels.Trip;

namespace TravelAgency.Web.Controllers
{
    public class TripsController : Controller
    {
        private readonly TravelAgencyDbContext trips;
        public TripsController(TravelAgencyDbContext trips)
        {
            this.trips = trips;
        }

        public IActionResult All()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTripViewModel createTripViewModel)
        {
            return View();
        }
    }
}
