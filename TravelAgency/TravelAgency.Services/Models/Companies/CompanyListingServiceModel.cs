using AutoMapper;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Companies
{
    public class CompanyListingServiceModel : CompanyServiceModel, IHaveCustomMapping
    {
        public int Trips { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Company, CompanyListingServiceModel>().ForMember(c => c.Trips, cfg => cfg.MapFrom(c => c.Trips.Count));
        }
    }
}
