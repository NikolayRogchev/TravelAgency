using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Companies
{
    public class AdminCompanyListingServiceModel : IMapFrom<Company>
    {
        public string Name { get; set; }
    }
}
