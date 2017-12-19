using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Companies
{
    public class CompanyServiceModel : IMapFrom<Company>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
