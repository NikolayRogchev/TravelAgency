using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Services.Models.Trips;

namespace TravelAgency.Services.Contracts
{
    public interface ITripService
    {
        IEnumerable<TripListingServiceModel> All(int? companyId, string userId);
        void Create(string name, int companyId, int destinationId, int capacity, decimal price, string startDate, string endDate);
        void SignUp(string userId, int tripId);
        IEnumerable<TripListingServiceModel> AllByUser(string id);
        void Remove(int tripId, string userId);
        IEnumerable<CompanyTripListingServiceModel> AllByCompany(int id);
        void Delete(int id);
    }
}
