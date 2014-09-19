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
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Text;

namespace JonLong.CRM.Web.Controllers
{
    public class CustomerWarehouseController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var model = new WarehoseListViewModel();
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
                model.Shoes = ShoeManager.Instance.LoadShoes(user.CustomerCode);
                if (model.Shoes.Any())
                {
                    model.SelectedShoe = model.Shoes.First().Value;
                }
                model.Items = WarehouseManager.Instance.LoadCustomerList(user.CustomerCode, model.SelectedShoe);


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

        [RoleAuthorize]
        [HttpPost]
        public ActionResult Index(string shoe)
        {
            try
            {
                var model = GetModel(shoe);
                return View(model);

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
                return View("Error");
            }

        }

        [RoleAuthorize]
        public ActionResult ExportData(string shoe)
        {
            var grid = new GridView();
            var model = GetModel(shoe);
            DataTable table = new DataTable();
            table.Columns.Add("Model No.");
            table.Columns.Add("Stock");

            for (int i = 0; i < 18; i++)
            {
                if (i < model.ShoeSizes.Count)
                {
                    table.Columns.Add(model.ShoeSizes[i]);
                }
                else
                {
                    table.Columns.Add("");
                }

            }

            foreach (var item in model.Items)
            {
                DataRow dr = table.NewRow();
                dr["Model No."] = item.ModelNo;
                dr["Stock"] = item.Total;
                dr[model.ShoeSizes[0]] = item.Size1;
                dr[model.ShoeSizes[1]] = item.Size2;
                dr[model.ShoeSizes[2]] = item.Size3;
                dr[model.ShoeSizes[3]] = item.Size4;
                dr[model.ShoeSizes[4]] = item.Size5;
                dr[model.ShoeSizes[5]] = item.Size6;
                dr[model.ShoeSizes[6]] = item.Size7;
                dr[model.ShoeSizes[7]] = item.Size8;
                dr[model.ShoeSizes[8]] = item.Size9;
                dr[model.ShoeSizes[9]] = item.Size10;
                dr[model.ShoeSizes[10]] = item.Size11;
                dr[model.ShoeSizes[11]] = item.Size12;
                dr[model.ShoeSizes[12]] = item.Size13;
                dr[model.ShoeSizes[13]] = item.Size14;
                dr[model.ShoeSizes[14]] = item.Size15;
                dr[model.ShoeSizes[15]] = item.Size16;
                dr[model.ShoeSizes[16]] = item.Size17;
                dr[model.ShoeSizes[17]] = item.Size18;
                table.Rows.Add(dr);
            }

            DataRow row = table.NewRow();

            row["Model No."] = model.WarehouseCount;
            row["Stock"] = model.Total;
            row[model.ShoeSizes[0]] = model.Size1Total;
            row[model.ShoeSizes[1]] = model.Size2Total;
            row[model.ShoeSizes[2]] = model.Size3Total;
            row[model.ShoeSizes[3]] = model.Size4Total;
            row[model.ShoeSizes[4]] = model.Size5Total;
            row[model.ShoeSizes[5]] = model.Size6Total;
            row[model.ShoeSizes[6]] = model.Size7Total;
            row[model.ShoeSizes[7]] = model.Size8Total;
            row[model.ShoeSizes[8]] = model.Size9Total;
            row[model.ShoeSizes[9]] = model.Size10Total;
            row[model.ShoeSizes[10]] = model.Size11Total;
            row[model.ShoeSizes[11]] = model.Size12Total;
            row[model.ShoeSizes[12]] = model.Size13Total;
            row[model.ShoeSizes[13]] = model.Size14Total;
            row[model.ShoeSizes[14]] = model.Size15Total;
            row[model.ShoeSizes[15]] = model.Size16Total;
            row[model.ShoeSizes[16]] = model.Size17Total;
            row[model.ShoeSizes[17]] = model.Size18Total;
            table.Rows.Add(row);

            grid.DataSource = table;
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=Exported_Diners.xls");
            Response.ContentType = "application/excel";
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");

            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            grid.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();

            return View("index", model);
        }

        [RoleAuthorize]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                WarehouseManager.Instance.Delete(id);
                return this.Json(1);
            }
            catch (Exception ex)
            {
                return this.Json(ex.Message);
            }
        }

        private WarehoseListViewModel GetModel(string shoe)
        {
            var model = new WarehoseListViewModel();
            var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
            model.Items = WarehouseManager.Instance.LoadCustomerList(user.CustomerCode, shoe);
            model.SelectedShoe = shoe;
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

            return model;
        }
    }
}