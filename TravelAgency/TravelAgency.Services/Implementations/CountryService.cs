using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;

namespace TravelAgency.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly TravelAgencyDbContext db;
        public CountryService(TravelAgencyDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Country> All() => this.db.Countries.ToList();

        public Country Find(string country) => this.db.Countries.FirstOrDefault(c => c.Name == country);

        public Country FindById(int id) => this.db.Countries.FirstOrDefault(c => c.Id == id);
    }
}
