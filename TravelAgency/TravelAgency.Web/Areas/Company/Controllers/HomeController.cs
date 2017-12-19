using Microsoft.AspNetCore.Mvc;
using TravelAgency.Services.Contracts;

namespace TravelAgency.Web.Areas.Company.Controllers
{
    public class HomeController : BaseCompanyController
    {
        private readonly ICompanyService companies;
        public HomeController(ICompanyService companies)
        {
            this.companies = companies;
        }
        public IActionResult Index() => View(this.companies.AllByUser(User.Identity.Name)); 
    }
}
