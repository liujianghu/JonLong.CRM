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
        public ActionResult Index(string bno = "", int lx = 0)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                var model = new PreLoadCabinetModel();
                model.Guid = Guid.NewGuid().ToString();
                model.Bandnos = PreLoadCabinetManager.Instance.LoadBandno(user.CustomerCode);
                var tuple = PreLoadCabinetManager.Instance.LoadAviailable(user.CustomerCode, bno, lx);

                model.Items = new Dictionary<string, PreLoadCabinetItemModel>();
                foreach (var item in tuple.Item2)
                {
                    PreLoadCabinetItemModel itemModel = null;
                    string key = String.Format("{0}-{1}", item.BanderNo, item.ModelNo);
                    if (model.Items.ContainsKey(key))
                    {
                        itemModel = model.Items[key];
                    }
                    else
                    {
                        itemModel = new PreLoadCabinetItemModel();
                    }
                    if (item.WcSta == 3)
                    {
                        itemModel.Origin = item;
                    }
                    else if (item.WcSta == 8)
                    {
                        itemModel.Loading = item;
                    }
                    else
                    {
                        itemModel.Loaded = item;
                    }
                    model.Items[key] = itemModel;
                }

                foreach (var item in tuple.Item1)
                {
                    if (item.WcSta != 6)
                    {
                        continue;
                    }
                    model.SavedItems.Add(item);
                    model.SavedTotal.Total += item.Total;
                    model.SavedTotal.Size1Total += item.Size1;
                    model.SavedTotal.Size2Total += item.Size2;
                    model.SavedTotal.Size3Total += item.Size3;
                    model.SavedTotal.Size4Total += item.Size4;
                    model.SavedTotal.Size5Total += item.Size5;
                    model.SavedTotal.Size6Total += item.Size6;
                    model.SavedTotal.Size7Total += item.Size7;
                    model.SavedTotal.Size8Total += item.Size8;
                    model.SavedTotal.Size9Total += item.Size9;
                    model.SavedTotal.Size10Total += item.Size10;
                    model.SavedTotal.Size11Total += item.Size11;
                    model.SavedTotal.Size12Total += item.Size12;
                    model.SavedTotal.Size13Total += item.Size13;
                    model.SavedTotal.Size14Total += item.Size14;
                    model.SavedTotal.Size15Total += item.Size15;
                    model.SavedTotal.Size16Total += item.Size16;
                    model.SavedTotal.Size17Total += item.Size17;
                    model.SavedTotal.Size18Total += item.Size18;
                }

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

                PreLoadCabinetManager.Instance.Save(model);
                result.Filled = PreLoadCabinetManager.Instance.GetFilled(user.CustomerCode, model.TGuid, model.ContainerType);
                PreLoadCabinetManager.Instance.UpdateBfb(model.TGuid, result.Filled);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.ToString();
            }
            return this.Json(result);
        }

        [RoleAuthorize]
        public JsonResult Confirm(string guid, DateTime? fhrq, string gz)
        {
            var result = new PreLoadCabinetEditModel
            {
                IsSuccess = true
            };
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string message = PreLoadCabinetManager.Instance.Confirm(
                    guid, user.CustomerCode, fhrq, user.LoginName, gz);
                if (!String.IsNullOrEmpty(message))
                { 
                    result.Message = message; 
                }
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