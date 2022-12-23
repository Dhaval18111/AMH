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
    public class CartController : Controller
    {
        public readonly AbstractCartServices abstractCartServices;
        
        public CartController( AbstractCartServices abstractCartServices)            
        {
            this.abstractCartServices = abstractCartServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Cart_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractCartServices.Cart_All(pageParam, search,2);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Cart_Upsert(Cart Cart)
        {
            if (Cart.Cart_Id > 0)
            {
                Cart.Updatedby = 0;// ProjectSession.AdminId;
            }
            else
            {
                Cart.Createdby = 0;// ProjectSession.AdminId;
            }

            var result = abstractCartServices.Cart_Upsert(Cart);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost]
        public JsonResult Cart_ById(int Cart_Id = 0)
        {
            SuccessResult<AbstractCart> successResult = abstractCartServices.Cart_ById(Cart_Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Cart_ActInAct(int Cart_Id)
        {
            SuccessResult<AbstractCart> admin = new SuccessResult<AbstractCart>();

            try
            {
                int Updatedby = 0;// ProjectSession.AdminId;
                admin = abstractCartServices.Cart_ActInact(Cart_Id, Updatedby);
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
        public JsonResult Cart_Delete(int Cart_Id)
        {
            int DeletedBy = 1;//ProjectSession.AdminId;

            var result = abstractCartServices.Cart_Delete(Cart_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}