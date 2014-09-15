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
    public class JLWarehouseController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var model = new WarehoseListViewModel();
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.Items = WarehouseManager.Instance.LoadList(user.CustomerCode,"");
                model.Shoes = ShoeManager.Instance.LoadShoes(user.CustomerCode);

                model.WarehouseCount = model.Items.Count;

                foreach (var item in model.Items)
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