﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravelAgency.Data.Models;
using TravelAgency.Services.Admin;
using TravelAgency.Services.Admin.Implementations;
using TravelAgency.Services.Admin.Models;
using TravelAgency.Web.Areas.Admin.ViewModels.User;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly IMapper mapper;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService users, IMapper mapper, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.users = users;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult All()
        {
            IList<AdminUserListingServiceModel> users = this.users.All();
            IEnumerable<SelectListItem> roles = this.roleManager.Roles.Select(r => new SelectListItem { Text=r.Name, Value = r.Name });
            return View(new AdminUserListingViewModel
            { 
                Users = users,
                Roles = roles
            });
        }
        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(All));
            }
            User user = await userManager.FindByIdAsync(model.UserId);
            IdentityResult result = await this.userManager.AddToRoleAsync(user, model.Role);
            return RedirectToAction(nameof(All));
        }
    }
}