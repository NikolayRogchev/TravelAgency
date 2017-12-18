using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Services.Admin;
using TravelAgency.Services.Admin.Implementations;
using TravelAgency.Services.Admin.Models;
using TravelAgency.Web.Areas.Admin.ViewModels;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly IMapper mapper;
        public UsersController(IAdminUserService users, IMapper mapper)
        {
            this.users = users;
            this.mapper = mapper;
        }
        public IActionResult All()
        {
            IList<AdminUserListingServiceModel> users = this.users.All();
            return View(users);
        }
    }
}