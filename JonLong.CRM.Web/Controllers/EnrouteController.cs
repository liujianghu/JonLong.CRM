using JonLong.CRM.BLL;
using JonLong.CRM.Utilities;
using JonLong.CRM.Web.Common;
using JonLong.CRM.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace JonLong.CRM.Web.Controllers
{
    public class EnrouteController : Controller
    {

        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                var model = new EnrouteListViewModel();
                model.Enroutes = EnrouteManager.Instance.LoadList(user.CustomerCode, DateTime.Now.Date);
                model.IsSuperAdmin = AccountHelper.IsSuperAdmin(user);

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
            
        }

        [RoleAuthorize]
        [HttpPost]
        public JsonResult Receive(int id, string bundleNo)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                EnrouteManager.Instance.Receive(user.LoginName, bundleNo, id);
                return this.Json(1);
            }
            catch (Exception ex)
            {
                return this.Json(ex.Message);
            }
        }

        [RoleAuthorize]
        public ActionResult Detail(string etd, string bundleNo, string containerNo, string container)
        {
            try
            {
                var model = new EnrouteDetailViewModel();
                DateTime sendDate;
                DateTime.TryParse(etd, out sendDate);
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.Details = EnrouteManager.Instance.LoadDetail(user.CustomerCode
                    , sendDate
                    , bundleNo
                    , containerNo
                    , containerNo);

                model.EnrouteCount = model.Details.Count;

                foreach (var item in model.Details)
                {
                    model.Total += item.Total;
                    model.Size1Total += item.Size1;
                    model.Size2Total += item.Size2;
                    model.Size3Total += item.Size3;
                    model.Size4Total += item.Size4;
                    model.Size5Total += item.Size5;
                    model.Size6Total += item.Size6;
                    model.Size7Total += item.Size7;
                    model.Size8Total += item.Size8;
                    model.Size9Total += item.Size9;
                    model.Size10Total += item.Size10;
                    model.Size11Total += item.Size11;
                    model.Size12Total += item.Size12;
                    model.Size13Total += item.Size13;
                    model.Size14Total += item.Size14;
                    model.Size15Total += item.Size15;
                    model.Size16Total += item.Size16;
                    model.Size17Total += item.Size17;
                    model.Size18Total += item.Size18;
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

	}
}