using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMHAdmin.Infrastructure;
using AMHAdmin.Pages;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AMH.Entities.V1;

namespace AMHAdmin.Controllers
{
    public class ReportsController : Controller
    {

        [ActionName(Actions.UsersListing)]
        public ActionResult UsersListing()
        {
            return View();
        }

        [ActionName(Actions.FeedbackListing)]
        public ActionResult FeedbackListing()
        {
            return View();
        }

        [ActionName(Actions.OrderListing)]
        public ActionResult OrderListing()
        {
            return View();
        }
        
        [ActionName(Actions.PaymentListing)]
        public ActionResult PaymentListing()
        {
            return View();
        }
        

    }
}