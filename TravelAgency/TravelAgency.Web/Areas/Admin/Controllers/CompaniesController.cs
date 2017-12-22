using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;
using TravelAgency.Web.Areas.Admin.ViewModels.Company;
using static TravelAgency.Common.Enums;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class CompaniesController : BaseAdminController
    {
        private readonly IAdminCompanyService companies;
        private readonly UserManager<User> userManager;
        public CompaniesController(IAdminCompanyService companies, UserManager<User> userManager)
        {
            this.companies = companies;
            this.userManager = userManager;
        }
        public IActionResult All() => View(this.companies.All());

        [HttpGet]
        public IActionResult Create()
        {
            //var companies = this.companies.All();
            var users = this.userManager.Users.Select(u => u.UserName);
            string usersJoined = string.Join(';', users);
            return View(new CreateCompanyViewModel { Users = usersJoined });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {
            if (!string.IsNullOrEmpty(model.FormModel.Owner))
            {
                User user = await this.userManager.FindByNameAsync(model.FormModel.Owner);
                if (user == null)
                {
                    ModelState.AddModelError("", $"User {model.FormModel.Owner} not found");
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            this.companies.Create(model.FormModel.Name, model.FormModel.Owner);
            User owner = await userManager.FindByNameAsync(model.FormModel.Owner);
            IdentityResult addToRoleResult = await userManager.AddToRoleAsync(owner, WebConstants.CompanyOwnerRole);
            this.AddNotification($"Company {model.FormModel.Name} created", NotificationType.Success);
            return RedirectToAction(nameof(All));
        }
    }
}