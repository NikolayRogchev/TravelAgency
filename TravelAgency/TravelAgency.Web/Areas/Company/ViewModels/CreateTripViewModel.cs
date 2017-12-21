using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static TravelAgency.Common.Messages;

namespace TravelAgency.Web.Areas.Company.ViewModels
{
    public class CreateTripViewModel 
    {
        [Required]
        [StringLength(50, ErrorMessage = MaxLengthExceededMessage)]
        public string Name { get; set; }
        [Required]
        public int Destination { get; set; }
        [Range(1, 30)]
        public int Duration { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, 200)]
        public int Capacity { get; set; }
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        [Required]
        public int Company { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}
