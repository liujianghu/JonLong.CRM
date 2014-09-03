using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.Models;
using JonLong.CRM.BLL;
using JonLong.CRM.Web.Common;
using JonLong.CRM.Web.Models;

namespace JonLong.CRM.Web.Controllers
{
    public class RoleController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var model = new RoleListViewModel();
                model.Roles = RoleManager.Instance.LoadAll();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }

        }

        [RoleAuthorize]
        public ActionResult Create()
        {
            var model = new RoleModel();
            return View(model);
        }

        [RoleAuthorize]
        [HttpPost]
        public ActionResult Create(RoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Please input role name");
                    return View(model);
                }

                if (!model.SelectedPermissions.Any())
                {
                    ModelState.AddModelError("", "Please select some permssions.");
                    return View(model);
                }

                bool isSuccess = RoleManager.Instance.Insert(model.RoleName, model.SelectedPermissions);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error hanppen, check your input.");
                    return View(model);
                }

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        [RoleAuthorize]
        public ActionResult Edit(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return RedirectToAction("index");
                }

                var role = RoleManager.Instance.LoadById(id);
                if (role == null)
                {
                    TempData["Error"] = "This record doesn't exists.";
                    return View("Error");
                }
                var model = new RoleModel
                {
                   RoleId = id,
                   RoleName = role.Name,
                   SelectedPermissions = role.Permissions
                };

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
        public ActionResult Edit(RoleModel model)
        {
            if (model == null)
            {
                TempData["Error"] = "The post data is null";
                return View("Error");
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please input role name");
                return View(model);
            }

            if (!model.SelectedPermissions.Any())
            {
                ModelState.AddModelError("", "Please select some permssions.");
                return View(model);
            }
            try
            {
                var role = new Role
                {
                    RoleId = model.RoleId,
                    Name = model.RoleName,
                    Permissions = model.SelectedPermissions
                };
                bool isSuccess = RoleManager.Instance.Update(role);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Error hanppen, check your input.");
                    return View(model);
                }

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

        [RoleAuthorize]
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                RoleManager.Instance.Delete(id);
                return this.Json(true);
            }
            catch (Exception)
            {
                //log exception
                return this.Json(false);
            }
        }


    }
}