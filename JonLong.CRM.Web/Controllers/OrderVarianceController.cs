using JonLong.CRM.Web.Common;
using JonLong.CRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.BLL;
using JonLong.CRM.Models;
using JonLong.CRM.Utilities;

namespace JonLong.CRM.Web.Controllers
{
    public class OrderVarianceController : Controller
    {

        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var model = new VarianceListViewModel();
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.Variances = OrderVarianceManager.Instance.LoadOrderVariance(AccountHelper.IsSuperAdmin(user), user.CustomerCode);
                model.Orders = OrderVarianceManager.Instance.LoadOrder(user.CustomerCode);
                model.Shipments = OrderVarianceManager.Instance.LoadShipments(user.CustomerCode);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");

            }
        }

        [RoleAuthorize]
        public ActionResult VarianceDetail(
              string customerCode
            , string etd
            , string bundleNo
            , string containerType
            , string containerNo
            , string guid)
        {
            try
            {
                var model = new VarianceDetailViewModel();
                DateTime sendDate;
                DateTime.TryParse(etd, out sendDate);
                model.VarianceDetails = OrderVarianceManager.Instance.LoadDetail(
                    customerCode,
                    sendDate,
                    bundleNo,
                    containerType,
                    containerNo.Trim(' '));
                model.Guid = guid;

                model.VarianceCount = model.VarianceDetails.Count;

                foreach (var item in model.VarianceDetails)
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

                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(user.CustomerCode);
                }

                return PartialView(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }

        }

        [RoleAuthorize]
        public ActionResult Edit(int id, string guid)
        {
            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "The id paramater incorrect.";
                    return View("Error");
                }
                var model = new VarianceEditViewModel();
                model.Detail = OrderVarianceManager.Instance.LoadById(id);
                model.Guid = guid;
                
                if (model.Detail == null)
                {
                    TempData["Error"] = "This data is not exists.";
                    return View("Error");
                }
                
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string customerCode = String.Empty;
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    customerCode = user.CustomerCode;
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(user.CustomerCode);
                }
                model.Containers = Constants.Containers;

                var statistics = OrderManager.Instance.LoadOrderStatistics(
                    customerCode
                    , null
                    , null
                    , String.Empty
                    , String.Empty);
                if (statistics == null)
                {
                    TempData["Error"] = "This data is missing, please try again.";
                    return View("Error");
                }

                model.BundleNos = new Dictionary<string, string>();

                foreach (var item in statistics)
                {
                    model.BundleNos.Add(item.BanderNo, item.SendDate.ToString("yyyy-MM-dd"));
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
        [HttpPost]
        public ActionResult Edit(VarianceEditModel model)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.LoginName = user.LoginName;
                model.EditType = 0;
                model.CustomerCode = user.CustomerCode;

                string message = OrderVarianceManager.Instance.Edit(model);
                if (!String.IsNullOrEmpty(message))
                {
                    TempData["Error"] = message;
                    return View("Error");
                }
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
        }

        [RoleAuthorize]
        public ActionResult Cancel(int id, string guid)
        {
            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "The id paramater incorrect.";
                    return View("Error");
                }
                var model = new VarianceEditViewModel();
                model.Detail = OrderVarianceManager.Instance.LoadById(id);
                model.Guid = guid;

                if (model.Detail == null)
                {
                    TempData["Error"] = "This data is not exists.";
                    return View("Error");
                }

                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string customerCode = String.Empty;
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    customerCode = user.CustomerCode;
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(user.CustomerCode);
                }
                model.Containers = Constants.Containers;

                var statistics = OrderManager.Instance.LoadOrderStatistics(
                    customerCode
                    , null
                    , null
                    , String.Empty
                    , String.Empty);
                if (statistics == null)
                {
                    TempData["Error"] = "This data is missing, please try again.";
                    return View("Error");
                }

                model.BundleNos = new Dictionary<string, string>();

                foreach (var item in statistics)
                {
                    model.BundleNos.Add(item.BanderNo, item.SendDate.ToString("yyyy-MM-dd"));
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
        [HttpPost]
        public ActionResult Cancel(VarianceEditModel model)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.LoginName = user.LoginName;
                model.EditType = 1;
                model.CustomerCode = user.CustomerCode;

                string message = OrderVarianceManager.Instance.Edit(model);
                if (!String.IsNullOrEmpty(message))
                {
                    TempData["Error"] = message;
                    return View("Error");
                }
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
        }

        [RoleAuthorize]
        [HttpGet]
        public ActionResult Order(
            string customerCode,
            string etd,
            string bundleNo,
            string containerType,
            string containerNo)
        {
            try
            {
                var model = new VarianceDetailViewModel();
                DateTime sendDate;
                DateTime.TryParse(etd, out sendDate);
                model.VarianceDetails = OrderVarianceManager.Instance.LoadOrderDetail(
                    customerCode,
                    sendDate,
                    bundleNo,
                    containerType,
                    containerNo.Trim(' '));

                model.VarianceCount = model.VarianceDetails.Count;

                foreach (var item in model.VarianceDetails)
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

                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(user.CustomerCode);
                }

                return PartialView(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
        }

        [RoleAuthorize]
        [HttpGet]
        public ActionResult Shipment(
            string customerCode, 
            string etd,
            string bundleNo,
            string containerType,
            string containerNo)
        {
            try
            {
                var model = new VarianceDetailViewModel();
                DateTime sendDate;
                DateTime.TryParse(etd, out sendDate);
                model.VarianceDetails = OrderVarianceManager.Instance.LoadShipmentDetail(
                    customerCode,
                    sendDate,
                    bundleNo,
                    containerType,
                    containerNo.Trim(' '));

                model.VarianceCount = model.VarianceDetails.Count;

                foreach (var item in model.VarianceDetails)
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

                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(user.CustomerCode);
                }

                return PartialView(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
        }


    }
}