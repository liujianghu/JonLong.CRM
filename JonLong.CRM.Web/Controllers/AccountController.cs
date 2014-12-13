using JonLong.CRM.Web.Common;
using JonLong.CRM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JonLong.CRM.BLL;
using JonLong.CRM.Models;
using Newtonsoft.Json;

namespace JonLong.CRM.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please input username and password！");
                return View(model);
            }

            try
            {
                string pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1");
                var user = UserManager.Instance.Login(model.UserName, pwd);
                if (user == null || user.UserId ==0)
                {
                    ModelState.AddModelError("", "Username or password incorrect！");
                    return View(model);
                }

                string userJson = JsonConvert.SerializeObject(user);

                //AuthorizationManager.SetTicket(Response, model.RememberMe, identity, name, roleId);
                FormsAuthentication.SetAuthCookie(userJson, model.RememberMe);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }

                //return RedirectToAction("index", "home");
                //暂时不启用首页，登录后访问ORDER 20140917 by duan
                return RedirectToAction("index", "Order");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Exception happened!");
                return View(model);
            }

            
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

    }
}