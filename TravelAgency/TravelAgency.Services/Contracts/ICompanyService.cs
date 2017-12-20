using System.Collections.Generic;
using TravelAgency.Data.Models;
using TravelAgency.Services.Models.Companies;

namespace TravelAgency.Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyListingServiceModel> AllByUser(string userName);
        CompanyServiceModel GetName(int id);
        bool CompanyExist(int id);
        Company Find(string company);
        Company FindById(int companyId);
    }
}
