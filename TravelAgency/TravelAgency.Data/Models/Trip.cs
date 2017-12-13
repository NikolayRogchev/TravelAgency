using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

using static TravelAgency.Common.Messages;

namespace TravelAgency.Data.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = MaxLengthExceededMessage)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = MaxLengthExceededMessage)]
        public Country Destination { get; set; }
        public int DestinationId { get; set; }
        public int Duration { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, 200)]
        public int Capacity { get; set; }
        public List<UserTrip> SignedUsers { get; set; } = new List<UserTrip>();
    }
}
