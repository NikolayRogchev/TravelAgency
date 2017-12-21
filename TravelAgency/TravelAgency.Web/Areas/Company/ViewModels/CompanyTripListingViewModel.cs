using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Web.Areas.Company.ViewModels
{
    public class CompanyTripListingViewModel
    {
        public string Company { get; set; }
        public IEnumerable<CompanyTripListingServiceModel> Trips { get; set; }
    }
}
