using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Common.Mapping;

namespace TravelAgency.Web.ViewModels.Trip
{
    public class CreateTripViewModel
    {
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = Messages.MaxLengthExceededMessage)]
        public string Destination { get; set; }
        [Range(1, 30)]
        public int Duration { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, 200)]
        public int Capacity { get; set; }
        public List<string> SignedUsers { get; set; }
        public string Company { get; set; }
    }
}
