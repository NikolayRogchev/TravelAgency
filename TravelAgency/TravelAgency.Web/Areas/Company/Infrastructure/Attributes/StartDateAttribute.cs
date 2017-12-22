using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Web.Areas.Company.ViewModels;

namespace TravelAgency.Web.Areas.Company.Infrastructure.Attributes
{
    public class StartDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CreateTripViewModel model = validationContext?.ObjectInstance as CreateTripViewModel;
            if (model != null && model.StartDate >= model.EndDate)
            {
                return new ValidationResult("Start Date should be before End Date!");
            }
            return ValidationResult.Success;
        }
    }
}
