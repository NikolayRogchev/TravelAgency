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
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Owner { get; set; }
    }
}
