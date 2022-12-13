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
    public class CustomerController : Controller
    {
        public readonly AbstractCustomerServices abstractCustomerServices;
        public readonly AbstractMasterCountryServices abstractMasterCountryServices;
        public readonly AbstractMasterStateServices abstractMasterStateServices;
        public readonly AbstractMasterCityServices abstractMasterCityServices;
        
        public CustomerController(
            AbstractCustomerServices abstractCustomerServices,
            AbstractMasterCountryServices abstractMasterCountryServices,
            AbstractMasterStateServices abstractMasterStateServices,
            AbstractMasterCityServices abstractMasterCityServices)
            
        {
            this.abstractCustomerServices = abstractCustomerServices;
            this.abstractMasterCountryServices = abstractMasterCountryServices;
            this.abstractMasterStateServices = abstractMasterStateServices;
            this.abstractMasterCityServices = abstractMasterCityServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.MasterCountry_All = MasterCountry_All();
            //ViewBag.MasterState_All = MasterState_All();
            //ViewBag.MasterCity_All = MasterCity_All();
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

            var result = abstractMasterCountryServices.MasterCountry_All(pageParam, "");

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

            var successResult = abstractMasterStateServices.MasterState_All(pageparam,"", CountryId);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult MasterCity(int StateId = 0)
        {
            PageParam pageparam = new PageParam();
            pageparam.Offset = 0;
            pageparam.Limit = 99999;

            var successResult = abstractMasterCityServices.MasterCity_All(pageparam, "", StateId);
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



        public JsonResult Customer_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractCustomerServices.Customer_All(pageParam, search);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Customer_Upsert(Customer customer)
        {
            if (customer.Id > 0)
            {
                customer.UpdatedBy = ProjectSession.AdminId;
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

                customer.CreatedBy = ProjectSession.AdminId;
            }

            var result = abstractCustomerServices.Customer_Upsert(customer);
            //if (result != null && result.Code == 200)
            //{
            //    if (customer.Id > 0)
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
        public JsonResult Customer_ById(string SMId = "MA==")
        {
            long Id = Convert.ToInt64(ConvertTo.Base64Decode(SMId));
            SuccessResult<AbstractCustomer> successResult = abstractCustomerServices.Customer_ById(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Customer_ActInAct(long Id)
        {
            SuccessResult<AbstractCustomer> admin = new SuccessResult<AbstractCustomer>();

            try
            {
                admin = abstractCustomerServices.Customer_ActInAct(Id);
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
        public JsonResult Customer_Delete(long Id)
        {
            long DeletedBy = ProjectSession.AdminId;

            var result = abstractCustomerServices.Customer_Delete(Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}