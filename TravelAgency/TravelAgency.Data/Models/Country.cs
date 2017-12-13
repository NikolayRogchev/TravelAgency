using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TravelAgency.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}
