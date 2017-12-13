using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TravelAgency.Data.Models
{
    public class User : IdentityUser
    {
        public List<UserTrip> SignedTrips { get; set; } = new List<UserTrip>();
    }
}
