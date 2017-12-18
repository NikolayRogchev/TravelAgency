using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common.Mapping;
using TravelAgency.Services.Admin.Models;

namespace TravelAgency.Web.Areas.Admin.ViewModels
{
    public class AdminUserListingViewModel : IMapFrom<AdminUserListingServiceModel>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
