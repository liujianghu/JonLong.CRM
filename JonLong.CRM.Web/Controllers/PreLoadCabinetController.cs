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
                var tuple = PreLoadCabinetManager.Instance.LoadAviailable(user.CustomerCode);

                model.Items = new Dictionary<string, PreLoadCabinetItemModel>();
                foreach (var item in tuple.Item2)
                {
                    PreLoadCabinetItemModel itemModel = null;
                    if (model.Items.ContainsKey(item.BanderNo))
                    {
                        itemModel = model.Items[item.BanderNo];
                    }
                    else
                    {
                        itemModel = new PreLoadCabinetItemModel();
                    }
                    if (item.WcSta == 3)
                    {
                        itemModel.Origin = item;
                    }
                    else if (item.WcSta == 6)
                    {
                        itemModel.Loaded = item;
                    }
                    else
                    {
                        itemModel.Loading = item;
                    }
                    model.Items[item.BanderNo] = itemModel;
                }

                model.SavedItems = tuple.Item1.Where(t => t.WcSta == 3).ToList();

                model.Title = PreLoadCabinetManager.Instance.LoadTitle(user.CustomerCode);
                if (model.Title == null)
                {
                    model.Title = new CabinetTitle();
                }
                
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

            return PartialView(null);
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