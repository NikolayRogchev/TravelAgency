using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Data.Models;

namespace TravelAgency.Web.Areas.Admin.ViewModels.Company
{
    public class CreateCompanyFormModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Company name must be minumum 3 symbols long")]
        [MaxLength(50, ErrorMessage = "Company name must be maximum 50 symbols long")]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
    }
}
