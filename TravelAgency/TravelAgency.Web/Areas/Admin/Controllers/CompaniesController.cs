using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelAgency.Data.Models;
using TravelAgency.Services.Contracts;
using TravelAgency.Web.Areas.Admin.ViewModels.Company;

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

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCompanyFormModel model)
        {
            if (!string.IsNullOrEmpty(model.Owner))
            {
                User user = await this.userManager.FindByNameAsync(model.Owner);
                if (user == null)
                {
                    ModelState.AddModelError("", $"User {model.Owner} not found");
                }
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            this.companies.Create(model.Name, model.Owner);
            return RedirectToAction(nameof(All));
        }
    }
}