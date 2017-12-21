using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Trips
{
    public class CompanyTripListingServiceModel : IMapFrom<Trip>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
