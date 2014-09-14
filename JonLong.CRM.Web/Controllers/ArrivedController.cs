using JonLong.CRM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.Models;
using JonLong.CRM.BLL;
using JonLong.CRM.Utilities;
using JonLong.CRM.Web.Models;

namespace JonLong.CRM.Web.Controllers
{
    public class ArrivedController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                var model = new ArrivedListViewModel
                {
                    StartETD = DateTime.Now.AddMonths(-2).Date,
                    EndETD = DateTime.Now.Date
                };
                model.Items = ArrivedManager.Instance.LoadList(user.CustomerCode, DateTime.Now.AddMonths(-2)
                    , DateTime.Now
                    , ""
                    , "");
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
        public ActionResult Index(ArrivedQueryModel query)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                var model = new ArrivedListViewModel
                {
                    StartETD = query.StartETD,
                    EndETD = query.EndETD,
                    BundleNo = query.BundleNo,
                    Container = query.Container
                };
                model.Items = ArrivedManager.Instance.LoadList(user.CustomerCode
                    , query.StartETD
                    , query.EndETD
                    , query.BundleNo
                    , query.Container);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }

        }

        [RoleAuthorize]
        public ActionResult Detail(string etd, string bundleNo, string containerNo, string container)
        {
            try
            {
                var model = new ArrivedDetailViewModel();
                DateTime sendDate;
                DateTime.TryParse(etd, out sendDate);
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.Details = ArrivedManager.Instance.LoadDetail(user.CustomerCode
                    , sendDate
                    , bundleNo
                    , containerNo
                    , containerNo);

                model.ArrivedCount = model.Details.Count;

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