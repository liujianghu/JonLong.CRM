using JonLong.CRM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.Models;
using JonLong.CRM.BLL;
using JonLong.CRM.Web.Models;
using JonLong.CRM.Utilities;

namespace JonLong.CRM.Web.Controllers
{
    public class PreLoadCabinetController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                var model = new PreLoadCabinetModel();
                model.Guid = Guid.NewGuid().ToString();
                model.Items = PreLoadCabinetManager.Instance.LoadAviailable(user.CustomerCode);
                
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(user.CustomerCode);
                }

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
            
        }

        [RoleAuthorize]
        public ActionResult PreLoad(int index)
        {
            var model =  new PreLoadCabinetItemModel
            {
                Index = index
            };

            return PartialView(model);
        }

        [RoleAuthorize]
        public JsonResult Save(PreLoadCabinet model)
        {
            var result = new PreLoadCabinetEditModel
            {
                IsSuccess = true
            };
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.CustomerCode = user.CustomerCode;
                
                int id = model.Id;
                if (id >0)
                {
                    PreLoadCabinetManager.Instance.Update(model);
                }
                else
                {
                    id = PreLoadCabinetManager.Instance.Insert(model);
                }

                result.Id = id;

                result.Filled = PreLoadCabinetManager.Instance.GetFilled(user.CustomerCode, model.TGuid, model.ContainerType);
                
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.ToString();
            }
            return this.Json(result);
        }

	}
}