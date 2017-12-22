using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Web.Areas.Company.ViewModels
{
    public class EditTripViewModel : IMapFrom<Trip>
    {
        public EditTripServiceModel Trip { get; set; }
        //public IEnumerable<SelectListItem> Countries { get; set; }
        //public IEnumerable<SelectListItem> Companies { get; set; }
    }
}
