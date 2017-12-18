using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Services.Admin.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.Services.Admin.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly TravelAgencyDbContext db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminUserService(TravelAgencyDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IList<AdminUserListingServiceModel> All()
        {
            IList<AdminUserListingServiceModel> result = new List<AdminUserListingServiceModel>();
            Task.Run(async () => 
            {
                IList<User> users = this.db.Users.ToList();
                foreach (User user in users)
                {
                    result.Add(new AdminUserListingServiceModel
                    {
                        Email = user.Email,
                        Roles = await this.userManager.GetRolesAsync(user),
                        UserName = user.UserName
                    });
                }
            }).Wait();
            return result;
        }
    }
}
