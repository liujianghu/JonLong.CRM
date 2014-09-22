using JonLong.CRM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JonLong.CRM.Models;
using JonLong.CRM.BLL;

namespace JonLong.CRM.Web.Controllers
{
    public class PreLoadCabinetController : Controller
    {
        [RoleAuthorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}