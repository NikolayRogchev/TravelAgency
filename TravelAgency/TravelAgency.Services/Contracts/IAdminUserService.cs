using System.Collections.Generic;
using TravelAgency.Services.Models.Users;

namespace TravelAgency.Services.Contracts
{
    public interface IAdminUserService
    {
        IList<AdminUserListingServiceModel> All();
    }
}
