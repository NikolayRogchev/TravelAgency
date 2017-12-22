using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using TravelAgency.Common;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Trips
{
    public class EditTripServiceModel : IMapFrom<Trip>, IHaveCustomMapping
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = Messages.MaxLengthExceededMessage)]
        public string Name { get; set; }
        public string Destination { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, 200)]
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Trip, EditTripServiceModel>().ForMember(t => t.CompanyName, cfg => cfg.MapFrom(t => t.Company.Name));
            profile.CreateMap<Trip, EditTripServiceModel>().ForMember(t => t.Destination, cfg => cfg.MapFrom(t => t.Destination.Name));
        }
    }
}
