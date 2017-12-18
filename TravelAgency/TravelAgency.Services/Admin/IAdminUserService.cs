using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Data.Models;
using TravelAgency.Services.Admin.Models;

namespace TravelAgency.Services.Admin
{
    public interface IAdminUserService
    {
        IList<AdminUserListingServiceModel> All();
    }
}
