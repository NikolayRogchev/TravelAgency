using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static TravelAgency.Common.Enums;

namespace TravelAgency.Web.Controllers
{
    public class BaseController : Controller
    {
        internal void AddNotification(string message, NotificationType type)
        {
            ViewBag.messageType = "info";
            ViewBag.message = message;
        }
    }
}