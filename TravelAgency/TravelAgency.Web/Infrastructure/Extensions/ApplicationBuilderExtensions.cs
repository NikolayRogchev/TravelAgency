using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Data;
using TravelAgency.Data.Models;

namespace TravelAgency.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<TravelAgencyDbContext>().Database.Migrate();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = WebConstants.AdministratorRole;

                        var roles = new[]
                        {
                            adminName,
                            WebConstants.CompanyOwnerRole,
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@mysite.com";

                        var adminUser = await userManager.FindByNameAsync(adminName);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                Email = adminEmail,
                                UserName = adminName,
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

                            IdentityResult createResult = await userManager.CreateAsync(adminUser, "admin");

                            IdentityResult addToRoleResult = await userManager.AddToRoleAsync(adminUser, adminName);
                        }
                    })
                    .Wait();
            }
            return app;
        }
    }
}
