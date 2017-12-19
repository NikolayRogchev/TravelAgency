using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TravelAgency.Common.Mapping;
using TravelAgency.Services.Models.Users;

namespace TravelAgency.Web.Areas.Admin.ViewModels.User
{
    public class AdminUserListingViewModel : IMapFrom<AdminUserListingServiceModel>
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
