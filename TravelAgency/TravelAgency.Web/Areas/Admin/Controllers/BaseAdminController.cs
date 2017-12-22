using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Common;
using static TravelAgency.Common.Enums;

namespace TravelAgency.Web.Areas.Admin.Controllers
{
    [Area(WebConstants.AdministratorArea)]
    [Authorize(Roles = WebConstants.AdministratorRole)]
    public class BaseAdminController : Controller
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