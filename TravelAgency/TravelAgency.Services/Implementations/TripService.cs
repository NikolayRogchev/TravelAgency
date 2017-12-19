using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Services.Implementations
{
    public class TripService : ITripService
    {
        private readonly TravelAgencyDbContext db;
        public TripService(TravelAgencyDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<TripListingServiceModel> All(int companyId)
        {
            return this.db.Trips.Where(t => t.Company.Id == companyId).ProjectTo<TripListingServiceModel>().ToList();
        }
    }
}
