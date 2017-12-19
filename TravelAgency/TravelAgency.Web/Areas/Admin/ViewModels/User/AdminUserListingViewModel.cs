using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common.Mapping;
using TravelAgency.Services.Admin.Models;

namespace TravelAgency.Web.Areas.Admin.ViewModels.User
{
    public class AdminUserListingViewModel : IMapFrom<AdminUserListingServiceModel>
    {
        public IEnumerable<AdminUserListingServiceModel> Users { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
