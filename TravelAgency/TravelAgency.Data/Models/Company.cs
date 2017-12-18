using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelAgency.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [Range(3, 50, ErrorMessage = "Company name must be between 3 and 50 symbols")]
        public string Name { get; set; }
        [Required]
        public User Owner { get; set; }
        public string OwnerId { get; set; }
        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}