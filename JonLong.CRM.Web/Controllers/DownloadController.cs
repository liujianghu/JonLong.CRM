using JonLong.CRM.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JonLong.CRM.Web.Controllers
{
    public class DownloadController : Controller
    {
        [RoleAuthorize]
        public FileResult Index(string fileName)
        {
            int extension = fileName.LastIndexOf(".");
            string contentType = fileName.Substring(extension);

            return File("~/Download/" + fileName, contentType, Server.UrlEncode(fileName));
        }
    }
}