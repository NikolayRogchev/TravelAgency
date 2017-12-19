using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.Data;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Companies;
using AutoMapper.QueryableExtensions;

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

        public bool CompanyExist(int id) => this.db.Companies.FirstOrDefault(c => c.Id == id) != null;

        public CompanyServiceModel GetName(int companyId)
            => this.db.Companies.Where(c => c.Id == companyId).ProjectTo<CompanyServiceModel>().FirstOrDefault();
    }
}