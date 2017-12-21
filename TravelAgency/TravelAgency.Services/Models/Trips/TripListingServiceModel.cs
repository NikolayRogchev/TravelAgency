using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using TravelAgency.Common.Mapping;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Models.Trips
{
    public class TripListingServiceModel : IMapFrom<Trip>, IHaveCustomMapping
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public int Duration { get; set; }
        [Display(Name = "Subscribed Users")]
        public int SignedUsersCount { get; set; }
        public string DestinationName { get; set; }
        [Display(Name = "From")]
        public DateTime StartDate { get; set; }
        [Display(Name = "To")]
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsSignedUp { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.SignedUsersCount, cfg => cfg.MapFrom(t => t.SignedUsers.Count));
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.CompanyName, cfg => cfg.MapFrom(t => t.Company.Name));
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.DestinationName, cfg => cfg.MapFrom(t => t.Destination.Name));
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.Duration, cfg => cfg.MapFrom(t => Math.Abs(t.Duration)));
        }
    }
}
