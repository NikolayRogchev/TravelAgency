using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Services.Admin.Models;

namespace TravelAgency.Services.Admin
{
    public interface IAdminCompanyService
    {
        IEnumerable<AdminCompanyListingServiceModel> All();
        void Create(string name, string ownerName);
    }
}
