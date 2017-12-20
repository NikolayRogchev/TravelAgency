using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Services.Implementations
{
    public class TripService : ITripService
    {
        private readonly TravelAgencyDbContext db;
        private readonly ICompanyService companies;
        private readonly ICountryService countries;
        public TripService(TravelAgencyDbContext db, ICompanyService companies, ICountryService countries)
        {
            this.db = db;
            this.companies = companies;
            this.countries = countries;
        }
        public IEnumerable<TripListingServiceModel> All(int? companyId, string userId)
        {
            List<TripListingServiceModel> signedTrips = this.db.Trips
                .Where(t => (companyId == null || t.Company.Id == companyId) && t.SignedUsers.Any(ut => ut.UserId == userId))
                .ProjectTo<TripListingServiceModel>(new { isSignedUp = true }).ToList();
            List<TripListingServiceModel> unSignedTrips = this.db.Trips
               .Where(t => (companyId == null || t.Company.Id == companyId) && !t.SignedUsers.Any(ut => ut.UserId == userId))
               .ProjectTo<TripListingServiceModel>(new { isSignedUp = false }).ToList();
            IEnumerable<TripListingServiceModel> result = signedTrips.Union(unSignedTrips);
            return result;
        }

        public void Create(string name, int companyId, int destinationId, int capacity, int duration, decimal price)
        {
            Company company = this.companies.FindById(companyId);
            Country country = this.countries.FindById(destinationId);
            this.db.Trips.Add(new Trip()
            {
                Name = name,
                Company = company,
                CompanyId = company.Id,
                Destination = country,
                DestinationId = country.Id,
                Capacity = capacity,
                Duration = duration,
                Price = price
            });
            this.db.SaveChanges();
        }

        public void SignUp(string userId, int tripId)
        {
            this.db.Trips.FirstOrDefault(t => t.Id == tripId).SignedUsers.Add(new UserTrip { TripId = tripId, UserId = userId });
            this.db.SaveChanges();
        }
    }
}
