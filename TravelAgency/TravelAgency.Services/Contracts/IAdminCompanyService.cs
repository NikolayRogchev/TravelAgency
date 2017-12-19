using System.Collections.Generic;
using TravelAgency.Services.Models.Companies;

namespace TravelAgency.Services.Contracts
{
    public interface IAdminCompanyService
    {
        IEnumerable<AdminCompanyListingServiceModel> All();
        void Create(string name, string ownerName);
    }
}
