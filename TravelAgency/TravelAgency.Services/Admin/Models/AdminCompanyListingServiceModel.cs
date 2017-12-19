using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Admin.Models
{
    public class AdminCompanyListingServiceModel : IMapFrom<Company>
    {
        public string Name { get; set; }
    }
}
