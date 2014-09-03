using JonLong.CRM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.BLL;
using JonLong.CRM.Models;
using JonLong.CRM.Web.Models;

namespace JonLong.CRM.Web.Controllers
{
    public class UserController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            try
            {
                var users = UserManager.Instance.LoadUserList();
                var model = new UserListViewModel();
                if (users != null)
                {
                    model.Users = users;
                }
                return View(model);

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

                var user = UserManager.Instance.LoadById(id);
                if (user == null)
                {
                    TempData["Error"] = "This user doesn't exists.";
                    return View("Error");
                }
                var roles = RoleManager.Instance.LoadAll();
                var userRole = UserManager.Instance.LoadUserRole(id);

                var model = new UserModel();
                model.User = user;
                if (roles != null)
                {
                    model.Roles = roles;
                }

                if (userRole != null)
                {
                    userRole.ForEach(t => model.UserRoles.Add(t.RoleId));
                }
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
        public ActionResult Edit(UserRoleModel model)
        {
            try
            {
                if (model ==null || model.UserId <=0)
                {
                    TempData["Error"] = "This post data is missing.";
                    return View("Error");
                }
                UserManager.Instance.SaveUserRoles(model.UserId, model.UserRoles);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Error");
            }
        }

    }
}