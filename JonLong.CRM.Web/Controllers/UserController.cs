using JonLong.CRM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.BLL;
using JonLong.CRM.Models;
using JonLong.CRM.Web.Models;
using System.Web.Security;

namespace JonLong.CRM.Web.Controllers
{
    public class UserController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index(string loginName = "")
        {
            try
            {
                var users = UserManager.Instance.LoadUserList(loginName);
                var model = new UserListViewModel();
                if (users != null)
                {
                    model.Users = users;
                }
                model.LoginName = loginName;
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

        [RoleAuthorize]
        [HttpGet]
        public ActionResult EditProfile()
        {
            try
            {
                var model = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);
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
        public JsonResult UpdatePassword(string oldpwd, string newpwd)
        {
            try
            {
                if (String.IsNullOrEmpty(oldpwd) || String.IsNullOrEmpty(newpwd))
                {
                    return this.Json("The password is empty");
                }
                var user = AccountHelper.GetLoginUserInfo(HttpContext.User.Identity);

                string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(oldpwd, "SHA1");
                string newPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(newpwd, "SHA1");
                bool isSuccess = UserManager.Instance.UpdatePassword(user.UserId, user.LoginName, pwd, newPassword);
                if (isSuccess)
                {
                    return this.Json(1);
                }

                return this.Json("The password is incorrect.");
            }
            catch (Exception ex)
            {
                return this.Json(ex.Message);
            }
        }

    }
}