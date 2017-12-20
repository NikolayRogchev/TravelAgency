using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Services.Contracts;
using TravelAgency.Web.ViewModels.Trip;

namespace TravelAgency.Web.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService trips;
        public TripsController(ITripService trips)
        {
            this.trips = trips;
        }

        public IActionResult All() => View(this.trips.All(null));

        public IActionResult Create()
        {
            return View();
        }
    }
}
