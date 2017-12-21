using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelAgency.Common;
using static TravelAgency.Common.Enums;

namespace TravelAgency.Web.Areas.Company.Controllers
{
    [Area(WebConstants.CompanyArea)]
    [Authorize(Roles = WebConstants.CompanyOwnerRole)]
    public class BaseCompanyController : Controller
    {
        internal void AddNotification(string message, NotificationType type)
        {
            ViewBag.messageType = (string)type.ToString();
            ViewBag.message = message;
        }
    }
}
