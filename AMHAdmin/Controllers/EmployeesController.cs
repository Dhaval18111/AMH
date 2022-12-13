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
    public class EmployeesController : Controller
    {
        public readonly AbstractEmployeesServices abstractEmployeesServices;
        public readonly AbstractMasterEmCountryServices abstractMasterEmCountryServices;
        public readonly AbstractMasterEmStateServices abstractMasterEmStateServices;
        public readonly AbstractMasterEmCityServices abstractMasterEmCityServices;
        
        public EmployeesController(
            AbstractEmployeesServices abstractEmployeesServices,
            AbstractMasterEmCountryServices abstractMasterEmCountryServices,
            AbstractMasterEmStateServices abstractMasterEmStateServices,
            AbstractMasterEmCityServices abstractMasterEmCityServices)
            
        {
            this.abstractEmployeesServices = abstractEmployeesServices;
            this.abstractMasterEmCountryServices = abstractMasterEmCountryServices;
            this.abstractMasterEmStateServices = abstractMasterEmStateServices;
            this.abstractMasterEmCityServices = abstractMasterEmCityServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.MasterCountry_All = MasterCountry_All();
            //ViewBag.MasterState_All = MasterState_All();
            //ViewBag.MasterCity_All = MasterCity_All();
            return View();
        }
        [ActionName(Actions.Calendar)]
        public ActionResult Calendar()
        {
            
            return View();
        }
        // User Type = Admin Type 
        [HttpPost]
        public IList<SelectListItem> MasterCountry_All()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;

            var result = abstractMasterEmCountryServices.MasterCountry_All(pageParam, "");

            items.Add(new SelectListItem() { Text = "All", Value = "0" });
            foreach (var master in result.Values)
            {
                items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
            }

            return items;
        }

        //[HttpPost]
        //public IList<SelectListItem> MasterState_All(long CountryId = 0)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    var result = abstractMasterStateServices.MasterState_All(pageParam, "", CountryId);

        //    items.Add(new SelectListItem() { Text = "All", Value = "0" });
        //    foreach (var master in result.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
        //    }

        //    return items;
        //}

        [HttpPost]
        public JsonResult MasterStateDrp(int CountryId = 0)
        {
            PageParam pageparam = new PageParam();
            pageparam.Offset = 0;
            pageparam.Limit = 99999;

            var successResult = abstractMasterEmStateServices.MasterState_All(pageparam,"", CountryId);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MasterCity(int StateId = 0)
        {
            PageParam pageparam = new PageParam();
            pageparam.Offset = 0;
            pageparam.Limit = 99999;

            var successResult = abstractMasterEmCityServices.MasterCity_All(pageparam, "", StateId);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public IList<SelectListItem> MasterCity_All(long StateId = 0)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    var result = abstractMasterCityServices.MasterCity_All(pageParam, "",StateId);

        //    items.Add(new SelectListItem() { Text = "All", Value = "0" });
        //    foreach (var master in result.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
        //    }

        //    return items;
        //}



        public JsonResult Employees_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractEmployeesServices.Employees_All(pageParam, search);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Employees_Upsert(Employees Employees)
        {
            if (Employees.Id > 0)
            {
                Employees.UpdatedBy = ProjectSession.AdminId;
            }
            else
            {
                //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                //var stringChars = new char[8];
                //var random = new Random();

                //for (int i = 0; i < stringChars.Length; i++)
                //{
                //    stringChars[i] = chars[random.Next(chars.Length)];
                //}

                Employees.CreatedBy = ProjectSession.AdminId;
            }

            var result = abstractEmployeesServices.Employees_Upsert(Employees);
            //if (result != null && result.Code == 200)
            //{
            //    if (Employees.Id > 0)
            //    {
            //        // Update
            //        var welcome = "Greetings From Ginny Buddy.";
            //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password + " Information Updated", result.Item.Password);

            //    }
            //    else
            //    {
            //        // Create
            //        var welcome = "Welcome to Ginny Buddy.";
            //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "", result.Item.Password);
            //    }
            //}
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public JsonResult Admin_Upsert(Admin admin)
        //{
        //    if (admin.Id > 0)
        //    {
        //        admin.UpdatedBy = ProjectSession.AdminId;
        //    }
        //    else
        //    {
        //        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //        var stringChars = new char[8];
        //        var random = new Random();

        //        for (int i = 0; i < stringChars.Length; i++)
        //        {
        //            stringChars[i] = chars[random.Next(chars.Length)];
        //        }

        //        admin.Password = new String(stringChars);
        //        admin.CreatedBy = ProjectSession.AdminId;
        //    }

        //    var result = abstractAdminServices.Admin_Upsert(admin);
        //    if (result != null && result.Code == 200)
        //    {
        //        if (admin.Id  > 0)
        //        {
        //            // Update
        //            var welcome = "Greetings From Ginny Buddy.";
        //            EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password +  " Information Updated", result.Item.Password);

        //        }
        //        else
        //        {
        //            // Create
        //            var welcome = "Welcome to Ginny Buddy.";
        //            EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "", result.Item.Password);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception(result.Message);
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult Employees_ById(string SMId = "MA==")
        {
            long Id = Convert.ToInt64(ConvertTo.Base64Decode(SMId));
            SuccessResult<AbstractEmployees> successResult = abstractEmployeesServices.Employees_ById(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Employees_ActInAct(long Id)
        {
            SuccessResult<AbstractEmployees> admin = new SuccessResult<AbstractEmployees>();

            try
            {
                admin = abstractEmployeesServices.Employees_ActInAct(Id);
            }
            catch (Exception ex)
            {
                admin.Code = 400;
                admin.Message = ex.Message;
            }
            admin.Item = null;
            return Json(admin, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Employees_Delete(long Id)
        {
            long DeletedBy = ProjectSession.AdminId;

            var result = abstractEmployeesServices.Employees_Delete(Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}