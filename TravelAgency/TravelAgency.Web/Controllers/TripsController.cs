using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Web.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService trips;
        private readonly UserManager<User> userManager;
        public TripsController(ITripService trips, UserManager<User> userManager)
        {
            this.trips = trips;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<TripListingServiceModel> trips = null;
            if (User.Identity.IsAuthenticated)
            {
                User user = await this.userManager.FindByNameAsync(User.Identity.Name);
                trips = this.trips.All(null, user.Id);
            }
            else
            {
                trips = this.trips.All(null, null);
            }
            return View(trips);
        }

        [Authorize]
        public async Task<IActionResult> SignUp(int id)
        {
            User user = await this.userManager.FindByNameAsync(User.Identity.Name);
            this.trips.SignUp(user.Id, id);
            return RedirectToAction(nameof(All));
        }
        [Authorize]
        public async Task<IActionResult> MyTrips()
        {
            User user = await this.userManager.FindByNameAsync(User.Identity.Name);
            IEnumerable<TripListingServiceModel> trips = this.trips.AllByUser(user.Id);
            return View(trips);
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(int id)
        {
            this.trips.Remove(id);
        }
    }
}
