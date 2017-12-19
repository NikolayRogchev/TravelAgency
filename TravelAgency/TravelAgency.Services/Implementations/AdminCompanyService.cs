using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;
using TravelAgency.Services.Models.Companies;

namespace TravelAgency.Services.Implementations
{
    public class AdminCompanyService : IAdminCompanyService
    {
        private readonly TravelAgencyDbContext db;
        private readonly UserManager<User> userManager;
        public AdminCompanyService(TravelAgencyDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }
        public IEnumerable<AdminCompanyListingServiceModel> All() => this.db.Companies.ProjectTo<AdminCompanyListingServiceModel>();

        public void Create(string name, string ownerName)
        {
            Task.Run(async () =>
            {
                User user = await this.userManager.FindByNameAsync(ownerName);
                if (user != null)
                {
                    this.db.Companies.Add(new Company
                    {
                        Name = name,
                        Owner = user,
                        OwnerId = user.Id
                    });
                    this.db.SaveChanges();
                }
            }).Wait();
        }
    }
}
