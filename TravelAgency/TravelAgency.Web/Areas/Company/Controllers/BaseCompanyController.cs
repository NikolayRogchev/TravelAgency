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
        internal void AddTempDataNotification(string message, NotificationType type)
        {
            this.AddNotification("TempData", message, type);
        }
        internal void AddViewBagNotification(string message, NotificationType type)
        {
            this.AddNotification("ViewBag", message, type);
        }
        internal void AddNotification(string container, string message, NotificationType type)
        {
            if (container == "ViewBag")
            {
                ViewBag.messageType = (string)type.ToString();
                ViewBag.message = message;
            }
            else if (container == "TempData")
            {
                TempData["messageType"] = (string)type.ToString();
                TempData["message"] = message;
            }
        }
    }
}
