using System;
using System.Collections.Generic;
using System.Text;
using TravelAgency.Data.Models;

namespace TravelAgency.Services.Contracts
{
    public interface ICountryService
    {
        Country Find(string country);
        IEnumerable<Country> All();
        Country FindById(int id);
    }
}
