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
        //public readonly AbstractUsersServices abstractUsersServices;


        //public ReportsController(
        //   AbstractUsersServices abstractUsersServices)

        //{
        //    this.abstractUsersServices = abstractUsersServices;

        //}
        [ActionName(Actions.UsersListing)]
        public ActionResult UsersListing()
        {
            //ViewBag.SubCategoryDrp = SubCategoryDrp();
            return View();
        }
        
        //// User Type = Admin Type 
        //[HttpPost]
        //public IList<SelectListItem> Department_All()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    var result = abstractDepartmentServices.Department_All(pageParam, "");

        //    items.Add(new SelectListItem() { Text = "All", Value = "0" });
        //    foreach (var master in result.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.DepartmentId) });
        //    }

        //    return items;
        //}

        ////[HttpPost]
        ////public IList<SelectListItem> MasterState_All(long CountryId = 0)
        ////{
        ////    List<SelectListItem> items = new List<SelectListItem>();

        ////    PageParam pageParam = new PageParam();
        ////    pageParam.Offset = 0;
        ////    pageParam.Limit = 0;

        ////    var result = abstractMasterStateServices.MasterState_All(pageParam, "", CountryId);

        ////    items.Add(new SelectListItem() { Text = "All", Value = "0" });
        ////    foreach (var master in result.Values)
        ////    {
        ////        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
        ////    }

        ////    return items;
        ////}


        //public JsonResult Student_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,int DepartmentId = 0)
        //{
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        string search = Convert.ToString(requestModel.Search.Value);
        //        var response = abstractStudentServices.Student_All(pageParam, search, DepartmentId);

        //        totalRecord = (int)response.TotalRecords;
        //        filteredRecord = (int)response.TotalRecords;

        //        return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public JsonResult Student_Upsert(Student Student)
        //{
        //    //if (Student.StudentId > 0)
        //    //{
        //    //    Student.UpdatedBy = ProjectSession.AdminId;
        //    //}
        //    //else
        //    //{
        //    //    //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //    //    //var stringChars = new char[8];
        //    //    //var random = new Random();

        //    //    //for (int i = 0; i < stringChars.Length; i++)
        //    //    //{
        //    //    //    stringChars[i] = chars[random.Next(chars.Length)];
        //    //    //}

        //    //    Student.CreatedBy = ProjectSession.AdminId;
        //    //}

        //    var result = abstractStudentServices.Student_Upsert(Student);
        //    //if (result != null && result.Code == 200)
        //    //{
        //    //    if (Student.Id > 0)
        //    //    {
        //    //        // Update
        //    //        var welcome = "Greetings From Ginny Buddy.";
        //    //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password + " Information Updated", result.Item.Password);

        //    //    }
        //    //    else
        //    //    {
        //    //        // Create
        //    //        var welcome = "Welcome to Ginny Buddy.";
        //    //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "", result.Item.Password);
        //    //    }
        //    //}
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public JsonResult Student_ById(string SMId = "MA==")
        //{
        //    int StudentId = Convert.ToInt32(ConvertTo.Base64Decode(SMId));
        //    SuccessResult<AbstractStudent> successResult = abstractStudentServices.Student_ById(StudentId);
        //    return Json(successResult, JsonRequestBehavior.AllowGet);
        //}


        //[HttpPost]
        //public JsonResult Student_Delete(int StudentId)
        //{
        //    var result = abstractStudentServices.Student_Delete(StudentId);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}