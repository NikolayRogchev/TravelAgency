using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Common;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    [Area(WebConstants.AdministratorArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class BaseAdminController : Controller
    {
    }
}