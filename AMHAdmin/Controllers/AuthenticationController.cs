using AMH.Common;
using AMHAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMH.Entities.V1;
using AMH.Services.Contract;
using AMH.Entities.Contract;

namespace AMHAdmin.Controllers
{
    public class AuthenticationController : Controller
    {
    //    #region Fields
    //    private readonly AbstractAdminServices abstractAdminServices;
    //    #endregion
    //    #region Ctor
    //    public AuthenticationController(AbstractAdminServices abstractAdminServices)
    //    {
    //        this.abstractAdminServices = abstractAdminServices;
    //    }
    //    #endregion

    //    #region Methods

    //    public ActionResult Signin()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public JsonResult Signin(string Email, string Password)
    //    {
    //        SuccessResult<AbstractAdmin> result = abstractAdminServices.Admin_SignIn(Email, Password);
    //        if (result.Code == 200 && result.Item != null)
    //        {
    //            Session.Clear();
    //            ProjectSession.AdminId = result.Item.Id;
    //            ProjectSession.AdminName = result.Item.Name;
    //            ProjectSession.LoginAdminEmail = result.Item.Email;
    //            ProjectSession.UserType = result.Item.AdminTypeName;

    //            HttpCookie cookie = new HttpCookie("AdminLogin");
    //            cookie.Values.Add("Id", result.Item.Id.ToString());
    //            cookie.Values.Add("Name", result.Item.Name);
    //            cookie.Values.Add("Email", result.Item.Email);
    //            cookie.Values.Add("UserType", result.Item.AdminTypeName);

    //            cookie.Expires = DateTime.Now.AddDays(30);
    //            Response.Cookies.Add(cookie);
    //        }
    //        return Json(result, JsonRequestBehavior.AllowGet);
    //    }


    //    public ActionResult Signout()
    //    {
    //        var result = abstractAdminServices.Admin_SignOut(ProjectSession.AdminId);
    //        if (result == true)
    //        {
    //            if (Request.Cookies["AdminLogin"] != null)
    //            {
    //                string[] myCookies = Request.Cookies.AllKeys;
    //                foreach (string cookie in myCookies)
    //                {
    //                    Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
    //                }
    //            }
    //        }


    //        Session.Clear();
    //        Session.Abandon();

    //        Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
    //        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //        Response.Cache.SetNoStore();
    //        return RedirectToAction(Actions.Signin, Pages.Controllers.Authentication);
    //    }

        
    //    #endregion
    }
}