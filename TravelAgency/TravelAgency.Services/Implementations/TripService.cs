using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
                .ProjectTo<TripListingServiceModel>().ToList();
            signedTrips.ForEach(x => x.IsSignedUp = true);
            List<TripListingServiceModel> unSignedTrips = this.db.Trips
               .Where(t => (companyId == null || t.Company.Id == companyId) && !t.SignedUsers.Any(ut => ut.UserId == userId))
               .ProjectTo<TripListingServiceModel>().ToList();
            unSignedTrips.ForEach(x => x.IsSignedUp = false);
            IEnumerable<TripListingServiceModel> result = signedTrips.Union(unSignedTrips);
            return result;
        }

        public IEnumerable<TripListingServiceModel> AllByUser(string id)
        {
            IEnumerable<Trip> trips = this.db.Trips.Include(t => t.SignedUsers).Where(t => t.SignedUsers.Any(ut => ut.UserId == id));
            List<TripListingServiceModel> result = trips.AsQueryable().ProjectTo<TripListingServiceModel>().ToList();
            result.ForEach(t => t.IsSignedUp = true);
            return result;
        }

        public void Create(string name, int companyId, int destinationId, int capacity, decimal price, string startDate, string endDate)
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
                Price = price,
                StartDate = startDate != null ? DateTime.Parse(startDate) : DateTime.Now,
                EndDate = startDate != null ? DateTime.Parse(startDate) : DateTime.Now.AddDays(7)
            });
            this.db.SaveChanges();
        }

        public void SignUp(string userId, int tripId)
        {
            try
            {
                this.db.Trips.FirstOrDefault(t => t.Id == tripId).SignedUsers.Add(new UserTrip { TripId = tripId, UserId = userId });
                this.db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void Remove(int tripId, string userId)
        {
            UserTrip trip = this.db.UserTrips.FirstOrDefault(ut => ut.UserId == userId && ut.TripId == tripId);
            this.db.UserTrips.Remove(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<CompanyTripListingServiceModel> AllByCompany(int id)
        {
            return this.db.Trips.Where(t => t.CompanyId == id).ProjectTo<CompanyTripListingServiceModel>().ToList();
        }

        public void Delete(int id)
        {
            Trip trip = this.db.Trips.FirstOrDefault(t => t.Id == id);
            if (trip != null)
            {
                this.db.Trips.Remove(trip);
                this.db.SaveChanges();
            }
        }
    }
}
