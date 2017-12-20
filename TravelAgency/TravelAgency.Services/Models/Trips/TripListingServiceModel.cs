using System;
using System.Collections.Generic;
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
        public int SubscribedUsers { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsSignedUp { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.SubscribedUsers, cfg => cfg.MapFrom(t => t.SignedUsers.Count));
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.Destination, cfg => cfg.MapFrom(t => t.Destination.Name));
            bool isSignedUp = false;
            profile.CreateMap<Trip, TripListingServiceModel>().ForMember(t => t.IsSignedUp, cfg => cfg.MapFrom(t => isSignedUp));
        }
    }
}
