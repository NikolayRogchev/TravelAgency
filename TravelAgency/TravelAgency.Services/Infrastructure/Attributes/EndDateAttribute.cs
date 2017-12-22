using System.ComponentModel.DataAnnotations;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Services.Infrastructure.Attributes
{
    public class EndDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            EditTripServiceModel model = validationContext?.ObjectInstance as EditTripServiceModel;
            if (model != null && model.StartDate >= model.EndDate)
            {
                return new ValidationResult("End Date should be after Start Date!");
            }
            return ValidationResult.Success;
        }
    }
}
