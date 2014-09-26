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
using Newtonsoft.Json;

namespace JonLong.CRM.Web.Controllers
{
    public class OrderController : Controller
    {

        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string customerCode = String.Empty;
                if (!AccountHelper.IsSuperAdmin(user))
                {
                    customerCode = user.CustomerCode;
                }

                string bundlerNo = "", containerNo = "", from = "", to = "";
                if (Request.Cookies["query"] != null)
                {
                    string queryJson = Request.Cookies["query"].Value;
                    var queryModel = JsonConvert.DeserializeObject<OrderQueryModel>(queryJson);
                    from = queryModel.ETDFrom;
                    to = queryModel.ETDTo;
                    bundlerNo = queryModel.BundleNo;
                    containerNo = queryModel.ContainerNo;
                }

                DateTime? sendDateFrom= null, sendDateTo = null;
                if (!String.IsNullOrEmpty(from))
                {
                    sendDateFrom = Convert.ToDateTime(from);
                }
                if (!String.IsNullOrEmpty(to))
                {
                    sendDateTo = Convert.ToDateTime(to);
                }

                var statistics = OrderManager.Instance.LoadOrderStatistics(
                      customerCode
                    , sendDateFrom
                    , sendDateTo
                    , bundlerNo
                    , containerNo);
                var model = new OrderStatisticsListViewModel();

                if (statistics != null && statistics.Any())
                {
                    model.Items = statistics;
                }

                model.ETDFrom = from;
                model.ETDTo = to;
                model.BundleNo = bundlerNo;
                model.ContainerNo = containerNo;
                model.SetTotal();
                return View(model);

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }

        }

        [RoleAuthorize]
        [HttpPost]
        public ActionResult Index(OrderQueryModel queryModel)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string customerCode = String.Empty;
                if (!AccountHelper.IsSuperAdmin(user))
                {
                    customerCode = user.CustomerCode;
                }

                string queryJson = JsonConvert.SerializeObject(queryModel);
                HttpCookie queryCookie = new HttpCookie("query");
                queryCookie.Value = queryJson;
                Response.SetCookie(queryCookie);

                DateTime? sendDateFrom = null;
                DateTime? sendDateTo = null;
                if (!String.IsNullOrEmpty(queryModel.ETDFrom))
                {
                    sendDateFrom = Convert.ToDateTime(queryModel.ETDFrom);
                }
                if (!String.IsNullOrEmpty(queryModel.ETDTo))
                {
                    sendDateTo = Convert.ToDateTime(queryModel.ETDTo);
                }

                var statistics = OrderManager.Instance.LoadOrderStatistics(
                      customerCode
                    , sendDateFrom
                    , sendDateTo
                    , queryModel.BundleNo
                    , queryModel.ContainerNo);

                var model = new OrderStatisticsListViewModel();
                model.BundleNo = queryModel.BundleNo;
                model.ContainerNo = queryModel.ContainerNo;
                model.ETDFrom = queryModel.ETDFrom;
                model.ETDTo = queryModel.ETDTo;

                if (statistics != null && statistics.Any())
                {
                    model.Items = statistics;
                }

                model.SetTotal();

                return View(model);

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        [RoleAuthorize]
        public ActionResult StatistscDetail(
              string sendDate
            , string customerCode
            , string bundlerNo
            , string containerNo
            , string container)
        {
            try
            {
                if (String.IsNullOrEmpty(sendDate))
                {
                    TempData["Error"] = "ETD is missing.";
                    return View("Error");
                }

                var model = new OrderStatisticsViewModel
                {
                    SendDate = sendDate,
                    BundleNo = bundlerNo,
                    ContainerType = containerNo
                };

                model.Orders = OrderManager.Instance.LoadStatisticsDetail(
                    Convert.ToDateTime(sendDate)
                    , customerCode
                    , bundlerNo
                    , containerNo
                    , container);

                model.OrderCount = model.Orders.Count;

                foreach (var item in model.Orders)
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
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        #region Edit

        [RoleAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                if (id <= 0)
                {
                    TempData["Error"] = "The id paramater incorrect.";
                    return View("Error");
                }
                var model = new OrderEditModel();
                var order = OrderManager.Instance.LoadOrderStatisticsById(id);
                if (order == null)
                {
                    TempData["Error"] = "This data is not exists.";
                    return View("Error");
                }
                model.Order = order;
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

                DateTime? sendDateFrom = null;
                DateTime? sendDateTo = null;
                string bundlerNo = String.Empty;
                string conainerNo = String.Empty;

                if (Request.Cookies["query"] != null)
                {
                    string queryJson = Request.Cookies["query"].Value;
                    var queryModel = JsonConvert.DeserializeObject<OrderQueryModel>(queryJson);
                    sendDateFrom = Convert.ToDateTime(queryModel.ETDFrom);
                    sendDateTo = Convert.ToDateTime(queryModel.ETDTo);
                    bundlerNo = queryModel.BundleNo;
                    conainerNo = queryModel.ContainerNo;
                }

                var statistics = OrderManager.Instance.LoadOrderStatistics(
                    customerCode
                    , sendDateFrom
                    , sendDateTo
                    , bundlerNo
                    , conainerNo);
                if (statistics == null)
                {
                    TempData["Error"] = "This data is missing, please try again.";
                    return View("Error");
                }

                model.BundleNos = new Dictionary<string, string>();

                foreach (var item in statistics)
                {
                    model.BundleNos.Add(item.BanderNo, item.SendDate.ToString("yyyy/M/dd"));
                }

                TempData["editModel"] = model;

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        [RoleAuthorize]
        [HttpPost]
        public ActionResult Edit(Order model)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.CustomerCode = Constants.SuperAdminDefaultCustomerCode;
                }
                else
                {
                    model.CustomerCode = user.CustomerCode;
                }

                string message = OrderManager.Instance.UpdateOrder(model, user.LoginName);
                OrderEditModel editModel;
                editModel = TempData["editModel"] as OrderEditModel;
                if (!String.IsNullOrEmpty(message))
                {
                    editModel.Message = message;
                    return View(editModel);
                }

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }
        }

        #endregion

        #region Create

        [RoleAuthorize]
        public ActionResult Create(string etd = "", string bundleNo = "", string containerType = "")
        {
            try
            {
                var model = new OrderCreateModel
                {
                    ETD = etd,
                    BundleNo = bundleNo,
                    ContainerType = containerType
                };

                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string customerCode = String.Empty;
                if (!AccountHelper.IsSuperAdmin(user))
                {
                    customerCode = user.CustomerCode;
                }
                model.BundlerNoList = OrderManager.Instance.LoadBundleNo(customerCode);
                if (String.IsNullOrEmpty(bundleNo))
                {
                    model.BundlerNoList.Insert(0, "");
                }

                model.ContainerTypes = Constants.Containers;
                model.ShoeList = ShoeManager.Instance.LoadShoes(customerCode);

                if (AccountHelper.IsSuperAdmin(user))
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(Constants.SuperAdminDefaultCustomerCode);
                }
                else
                {
                    model.ShoeSizes = ShoeManager.Instance.LoadShoeSize(customerCode);
                }

                TempData["createModel"] = model;
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }

        }

        [RoleAuthorize]
        [HttpPost]
        public ActionResult Create(OrderCreateModel model)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);

                var order = new Order();
                if (AccountHelper.IsSuperAdmin(user))
                {
                    order.CustomerCode = Constants.SuperAdminDefaultCustomerCode;
                }
                else
                {
                    order.CustomerCode = AccountHelper.GetCustomerCode(user.CustomerCode);
                }
                order.ModelNo = model.Shoe;
                order.ContainerType = model.ContainerType;
                order.SendDate = Convert.ToDateTime(model.ETD).Date;
                order.BanderNo = model.BundleNo;
                order.ContractNo = model.ContractNo;
                order.Size1 = model.Size1;
                order.Size2 = model.Size2;
                order.Size3 = model.Size3;
                order.Size4 = model.Size4;
                order.Size5 = model.Size5;
                order.Size6 = model.Size6;
                order.Size7 = model.Size7;
                order.Size8 = model.Size8;
                order.Size9 = model.Size9;
                order.Size10 = model.Size10;
                order.Size11 = model.Size11;
                order.Size12 = model.Size12;
                order.Size13 = model.Size13;
                order.Size14 = model.Size14;
                order.Size15 = model.Size15;
                order.Size16 = model.Size16;
                order.Size17 = model.Size17;
                order.Size18 = model.Size18;
                order.Size19 = model.Size19;
                order.Size20 = model.Size20;

                string message = OrderManager.Instance.Create(order, user.LoginName);
                OrderEditModel createModel;
                createModel = TempData["editModel"] as OrderCreateModel;
                if (!String.IsNullOrEmpty(message))
                {
                    createModel.Message = message;
                    return View(createModel);
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
        public JsonResult LoadContainer(string bundleNo)
        {
            var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
            string container = OrderManager.Instance.LoadContainer(user.CustomerCode, bundleNo);
            if (String.IsNullOrEmpty(container))
            {
                this.Json("");
            }

            return this.Json(container);
        }

        [RoleAuthorize]
        public JsonResult LoadSizeByShoe(string shoe)
        {
            var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
            var list = ShoeManager.Instance.LoadShoeSizeByShoe(user.CustomerCode, shoe);
            return this.Json(list);
        }

        #endregion

        [RoleAuthorize]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                string message = OrderManager.Instance.Delete(id, user.LoginName);
                if (String.IsNullOrEmpty(message))
                {
                    return this.Json(message);
                }
                return this.Json(1);
            }
            catch (Exception ex)
            {
                return this.Json(ex.Message);
            }
        }

        [RoleAuthorize]
        [HttpPost]
        public JsonResult ConvertToOrder(string bundleNo)
        {
            try
            {
                string message = OrderManager.Instance.ConverToModel(bundleNo);
                if (!String.IsNullOrEmpty(message))
                {
                    return this.Json(message);
                }
                return this.Json("1");
            }
            catch (Exception ex)
            {
                return this.Json(ex.Message);
            }
        }
    }
}
