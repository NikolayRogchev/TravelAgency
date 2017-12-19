using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.Data;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Companies;

namespace TravelAgency.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly TravelAgencyDbContext db;
        public CompanyService(TravelAgencyDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<CompanyListingServiceModel> AllByUser(string userName)
        {
            return this.db.Companies.Where(c => c.Owner.UserName == userName).ProjectTo<CompanyListingServiceModel>().ToList();
        }
    }
}
