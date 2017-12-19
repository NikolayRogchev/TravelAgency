using System.Collections.Generic;
using TravelAgency.Services.Models.Companies;

namespace TravelAgency.Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyListingServiceModel> AllByUser(string userName);
    }
}
