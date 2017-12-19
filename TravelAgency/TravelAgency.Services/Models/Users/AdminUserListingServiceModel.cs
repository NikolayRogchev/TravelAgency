using System.Collections.Generic;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Users
{
    public class AdminUserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
