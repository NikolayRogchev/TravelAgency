using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Web.Areas.Company.ViewModels
{
    public class TripListingViewModel
    {
        public IEnumerable<TripListingServiceModel> Trips { get; set; }
        public string Company { get; set; }
    }
}
